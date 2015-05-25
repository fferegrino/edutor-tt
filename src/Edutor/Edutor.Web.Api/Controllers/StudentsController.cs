using Edutor.Web.Api.MaintenanceProcessing;
using Edutor.Web.Api.Models.NewModels;
using Edutor.Web.Api.InquiryProcessing;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Edutor.Web.Api.Models.ReturnTypes;
using Edutor.Web.Api.Models;
using Edutor.Common;
using Edutor.Web.Common.Exceptions;
using Edutor.Web.Common.Filters;
using Edutor.Web.Api.Models.ModModels;

namespace Edutor.Web.Api.Controllers
{
    /// <summary>
    /// Conjunto de extremos REST que permiten operar con los servicios de creación y manipulación de estudiantes que ofrece la plataforma
    /// </summary>
    [Edutor.Web.Common.UnitOfWorkActionFilter]
    public class StudentsController : ApiController
    {
        private readonly IPostStudentMaintenanceProcessor _addUserQueryProcessor;
        private readonly IPatchStudentMaintenanceProcessor _patchStudent;
        private readonly IDeleteStudentMaintenanceProcessor _deleteStudent;
        private readonly IGetStudentsInquiryProcessor _getStudentsInquiryProcessor;
        private readonly IGetNotificationsInquiryProcessor _getNotifications;
        private readonly IPagedDataRequestFactory _pagedDataRequestFactory;
        private readonly IGetEventsInquiryProcessor _getEvents;
        private readonly IGetQuestionsInquiryProcessor _getQuestions;

        public StudentsController(IPostStudentMaintenanceProcessor addUserQueryProcessor,
            IGetStudentsInquiryProcessor getStudents,
            IGetNotificationsInquiryProcessor getNotifications,
            IPagedDataRequestFactory pagedDataRequest,
            IDeleteStudentMaintenanceProcessor deleteStudent,
            IPatchStudentMaintenanceProcessor patchStudent,
            IGetEventsInquiryProcessor getEvents,
            IGetQuestionsInquiryProcessor getQuestions)
        {
            _patchStudent = patchStudent;
            _addUserQueryProcessor = addUserQueryProcessor;
            _getStudentsInquiryProcessor = getStudents;
            _getNotifications = getNotifications;
            _pagedDataRequestFactory = pagedDataRequest;
            _getEvents = getEvents;
            _getQuestions = getQuestions;
            _deleteStudent = deleteStudent;
        }

        /// <summary>
        /// Regresa una lista paginada de todos los estudiantes registrados en el sistema
        /// </summary>
        /// <returns>Una lista paginada de todos los estudiantes registrados en el sistema</returns>
        [HttpGet]
        [ResponseType(typeof(PagedDataResponse<Student>))]
        [Route("students")]
        [Authorize(Roles = Constants.RoleNames.Administrator)]
        public PagedDataResponse<Student> GetStudents()
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var s = _getStudentsInquiryProcessor.GetAllStudents(request);
            return s;
        }

        /// <summary>
        /// Obtiene obtiene el estudiante indicado
        /// </summary>
        /// <param name="studentId">El identificador único del estudiante a recuperar</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(Student))]
        [Route("students/{studentId:int}")]
        [Authorize(Roles = Constants.RoleNames.All)]
        public Student GetStudentById(int studentId)
        {
            return _getStudentsInquiryProcessor.GetStudent(studentId);
        }

        /// <summary>
        /// Obtiene el estudiante indicado realizando la búsqueda mediante la CURP
        /// </summary>
        /// <param name="tutorId">La Clave Única de Registro de Población del usuario escolar</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(Student))]
        [Route("students/{curp:regex(" + Constants.CommonRoutingDefinitions.CurpRegex + ")}")]
        [Authorize(Roles = Constants.RoleNames.Administrator)]
        public Student GetStudent(string curp)
        {
            var s = _getStudentsInquiryProcessor.GetStudent(curp);
            return s;
        }

        /// <summary>
        /// Obtiene una lista paginada de las notificaciones para el estudiante
        /// </summary>
        /// <param name="studentId">El identificador único del estudiante del que se desea conocer sus notificaciones</param>
        /// <returns>Una lista paginada de las notificaciones para el estudiante</returns>
        [HttpGet]
        [Route("students/{studentId:int}/notifications")]
        [Authorize(Roles = Constants.RoleNames.Tutor)]
        public PagedDataResponse<Notification> GetNotificationsForStudent(int studentId)
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var r = _getNotifications.GetNotificationsForStudent(studentId, request);
            return r;
        }

        /// <summary>
        /// Obtiene una lista paginada de los eventos para el estudiante
        /// </summary>
        /// <param name="studentId">El identificador único del estudiante del que se desea conocer sus eventos</param>
        /// <returns>Una lista paginada de los eventos para el estudiante</returns>
        [HttpGet]
        [Route("students/{studentId:int}/events")]
        [Authorize(Roles = Constants.RoleNames.Tutor)]
        public PagedDataResponse<Event> GetEventsForStudent(int studentId)
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var r = _getEvents.GetEventsForStudent(studentId, request);
            return r;
        }

        /// <summary>
        /// Obtiene una lista paginada de las preguntas para el estudiante
        /// </summary>
        /// <param name="studentId">El identificador único del estudiante del que se desea conocer sus preguntas</param>
        /// <returns>Una lista paginada de las preguntas para el estudiante</returns>
        [HttpGet]
        [Route("students/{studentId:int}/questions")]
        [Authorize(Roles = Constants.RoleNames.Tutor)]
        public PagedDataResponse<Question> GetQuestionsForStudent(int studentId)
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var r = _getQuestions.GetQuestionsForStudent(studentId, request);
            return r;
        }

        /// <summary>
        /// Activa el estudiante con el token asignado
        /// </summary>
        /// <param name="token">El token asignado por el sistema</param>
        /// <returns>El estudiante activado</returns>
        [HttpPost]
        [ResponseType(typeof(Student))]
        [Route("students/{token:regex(" + Constants.CommonRoutingDefinitions.Token + ")}/activate")]
        public Student ActivateStudent(string token)
        {
            var s = _addUserQueryProcessor.ActivateStudent(token);
            return s;
        }

        /// <summary>
        /// Agrega un nuevo estudiante al sistema
        /// </summary>
        /// <param name="student">El estudiante que será añadido</param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(Student))]
        [Route("students")]
        [Authorize(Roles = Constants.RoleNames.Administrator)]
        [ValidationActionFilter]
        public IHttpActionResult AddStudent(NewStudent student)
        {
            var user = _addUserQueryProcessor.AddStudent(student);
            var result = new ModelPostedActionResult<Student>(Request, user);
            return result;
        }

        /// <summary>
        /// Modifica el estudiante de acuerdo a lo enviado en el parámetro <paramref name="student"/>
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("students/{studentId:int}")]
        [Authorize(Roles = Constants.RoleNames.Administrator)]
        public IHttpActionResult DeleteGroup(int studentId)
        {
            _deleteStudent.Delete(studentId);
            return new ModelDeletedActionResult(Request);
        }
    }
}
