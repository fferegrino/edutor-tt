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
        private readonly IGetStudentsInquiryProcessor _getStudentsInquiryProcessor;
        private readonly IGetNotificationsInquiryProcessor _getNotifications;
        private readonly IPagedDataRequestFactory _pagedDataRequestFactory;
        private readonly IGetEventsInquiryProcessor _getEvents;
        private readonly IGetQuestionsInquiryProcessor _getQuestions;

        public StudentsController(IPostStudentMaintenanceProcessor addUserQueryProcessor,
            IGetStudentsInquiryProcessor getStudents,
            IGetNotificationsInquiryProcessor getNotifications,
            IPagedDataRequestFactory pagedDataRequest,
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
        }


        /// <summary>
        /// Adds a new Tutor to the system
        /// </summary>
        /// <param name="newStudent">The tutor to be added</param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(Student))]
        [Route("students")]
        [Authorize(Roles = Constants.RoleNames.Administrator)]
        [ValidationActionFilter]
        public IHttpActionResult AddStudent(NewStudent newStudent)
        {
                var user = _addUserQueryProcessor.AddStudent(newStudent);
                var result = new ModelPostedActionResult<Student>(Request, user);
                return result;
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
        /// Obtiene el tutor indicado
        /// </summary>
        /// <param name="tutorId">El identificador único del tutor a recuperar</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(Student))]
        [Route("students/{curp:regex(" + Constants.CommonRoutingDefinitions.CurpRegex + ")}")]
        [Authorize(Roles = Constants.RoleNames.Administrator)]
        public Student GetTutor(string curp)
        {
            var s = _getStudentsInquiryProcessor.GetStudent(curp);
            return s;
        }

        /// <summary>
        /// Activa el estudiante con el token asignado
        /// </summary>
        /// <param name="token">El identificador único del tutor a recuperar</param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(Student))]
        [Route("students/{token:regex(" + Constants.CommonRoutingDefinitions.Token + ")}/activate")]
        public Student ActivateStudent(string token)
        {
            var s = _addUserQueryProcessor.ActivateStudent(token);
            return s;
        }

        /// <summary>
        /// Obtiene todos los tutores registrados en el sistema
        /// </summary>
        /// <returns>Una respuesta paginada de todos los tutores en el sistema</returns>
        [HttpGet]
        [ResponseType(typeof(PagedDataInquiryResponse<Student>))]
        [Route("students")]
        [Authorize(Roles = Constants.RoleNames.Administrator)]
        public PagedDataInquiryResponse<Student> GetTutors()
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var s = _getStudentsInquiryProcessor.GetAllStudents(request);
            return s;
        }

        /// <summary>
        /// Obtiene una lista de las notificaciones para el estudiante
        /// </summary>
        /// <param name="studentId">El identificador único del estudiante del que se desea conocer sus notificaciones</param>
        /// <returns>Una lista con las notificaciones del estudiante</returns>
        [HttpGet]
        [Route("students/{studentId:int}/notifications")]
        [Authorize(Roles = Constants.RoleNames.Tutor)]
        public PagedDataInquiryResponse<Notification> GetNotificationsForStudent(int studentId)
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var r = _getNotifications.GetNotificationsForStudent(studentId, request);
            return r;
        }

        /// <summary>
        /// Obtiene una lista de los eventos para el estudiante
        /// </summary>
        /// <param name="studentId">El identificador único del estudiante del que se desea conocer sus eventos</param>
        /// <returns>Una lista con los eventos del estudiante</returns>
        [HttpGet]
        [Route("students/{studentId:int}/events")]
        [Authorize(Roles = Constants.RoleNames.Tutor)]
        public PagedDataInquiryResponse<Event> GetEventsForStudent(int studentId)
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var r = _getEvents.GetEventsForStudent(studentId, request);
            return r;
        }


        /// <summary>
        /// Obtiene una lista de las preguntas para el estudiante
        /// </summary>
        /// <param name="studentId">El identificador único del estudiante del que se desea conocer sus preguntas</param>
        /// <returns>Una lista con las preguntas del estudiante</returns>
        [HttpGet]
        [Route("students/{studentId:int}/questions")]
        [Authorize(Roles = Constants.RoleNames.Tutor)]
        public PagedDataInquiryResponse<Question> GetQuestionsForStudent(int studentId)
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var r = _getQuestions.GetQuestionsForStudent(studentId, request);
            return r;
        }
    }
}
