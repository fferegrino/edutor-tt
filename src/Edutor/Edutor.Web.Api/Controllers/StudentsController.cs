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

        public StudentsController(IPostStudentMaintenanceProcessor addUserQueryProcessor, 
            IGetStudentsInquiryProcessor getStudents,
            IGetNotificationsInquiryProcessor getNotifications,
            IPagedDataRequestFactory pagedDataRequest)
        {
            _addUserQueryProcessor = addUserQueryProcessor;
            _getStudentsInquiryProcessor = getStudents;
            _getNotifications = getNotifications;
            _pagedDataRequestFactory = pagedDataRequest;
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
        public Student GetStudentById(int studentId)
        {
            return _getStudentsInquiryProcessor.GetStudent(studentId);
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

    }
}
