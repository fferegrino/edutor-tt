using Edutor.Web.Api.MaintenanceProcessing;
using Edutor.Web.Api.Models.NewModels;
using Edutor.Web.Api.InquiryProcessing;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Edutor.Web.Api.Models.ReturnTypes;
using Edutor.Web.Api.Models;

namespace Edutor.Web.Api.Controllers
{
    [Edutor.Web.Common.UnitOfWorkActionFilter]
    public class StudentsController : ApiController
    {
        private readonly IPostStudentMaintenanceProcessor _addUserQueryProcessor;
        private readonly IGetStudentsInquiryProcessor _getStudentsInquiryProcessor;
        private readonly IGetNotificationsInquiryProcessor _getNotifications;
        private readonly IPagedDataRequestFactory _pagedDataRequestFactory;
        private readonly IGetEventsInquiryProcessor _getEvents;
        private readonly IGetQuestionsInquiryProcessor _getQuestions;

        public StudentsController(IPostStudentMaintenanceProcessor addUserQueryProcessor, 
            IGetStudentsInquiryProcessor getStudents,
            IGetNotificationsInquiryProcessor getNotifications,
            IPagedDataRequestFactory pagedDataRequest,
            IGetEventsInquiryProcessor getEvents,
            IGetQuestionsInquiryProcessor getQuestions)
        {
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
        public IHttpActionResult AddStudent(NewStudent newStudent)
        {

            var user = _addUserQueryProcessor.AddStudent(newStudent);
            var result = new ModelPostedActionResult<Student>(Request, user);
            return result;
        }

        /// <summary>
        /// Obtiene obtiene el estudiante indicado
        /// </summary>
        /// <param name="studentId">El id del estudiante a recuperar</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(Student))]
        [Route("students/{studentId:int}")]
        public Student GetStudentById(int studentId)
        {
            return _getStudentsInquiryProcessor.GetStudent(studentId);
        }

        /// <summary>
        /// Obtiene el tutor indicado
        /// </summary>
        /// <param name="tutorId">El id del tutor a recuperar</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(Student))]
        [Route("students/{curp:regex(^[A-Za-z0-9]+$)}")]
        public Student GetTutor(string curp)
        {
            var s = _getStudentsInquiryProcessor.GetStudent(curp);
            return s;
        }

        /// <summary>
        /// Obtiene todos los tutores registrados en el sistema
        /// </summary>
        /// <returns>Una respuesta paginada de todos los tutores en el sistema</returns>
        [HttpGet]
        [ResponseType(typeof(PagedDataInquiryResponse<Student>))]
        [Route("students")]
        public PagedDataInquiryResponse<Student> GetTutors()
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var s  =_getStudentsInquiryProcessor.GetAllStudents(request);
            return s;
        }

        /// <summary>
        /// Obtiene una lista de las notificaciones para el estudiante
        /// </summary>
        /// <param name="studentId">El id del estudiante del que se desea conocer sus notificaciones</param>
        /// <returns>Una lista con las notificaciones del estudiante</returns>
        [HttpGet]
        [Route("students/{studentId:int}/notifications")]
        public PagedDataInquiryResponse<Notification> GetNotificationsForStudent(int studentId)
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var r = _getNotifications.GetNotificationsForStudent(studentId, request);
            return r;
        }

        /// <summary>
        /// Obtiene una lista de los eventos para el estudiante
        /// </summary>
        /// <param name="studentId">El id del estudiante del que se desea conocer sus eventos</param>
        /// <returns>Una lista con los eventos del estudiante</returns>
        [HttpGet]
        [Route("students/{studentId:int}/events")]
        public PagedDataInquiryResponse<Event> GetEventsForStudent(int studentId)
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var r = _getEvents.GetEventsForStudent(studentId, request);
            return r;
        }


        /// <summary>
        /// Obtiene una lista de las preguntas para el estudiante
        /// </summary>
        /// <param name="studentId">El id del estudiante del que se desea conocer sus preguntas</param>
        /// <returns>Una lista con las preguntas del estudiante</returns>
        [HttpGet]
        [Route("students/{studentId:int}/questions")]
        public PagedDataInquiryResponse<Question> GetQuestionsForStudent(int studentId)
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var r = _getQuestions.GetQuestionsForStudent(studentId, request);
            return r;
        }
    }
}
