using Edutor.Web.Api.MaintenanceProcessing;
using Edutor.Web.Api.Models.NewModels;
using Edutor.Web.Api.InquiryProcessing;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Edutor.Web.Api.Models.ReturnTypes;

namespace Edutor.Web.Api.Controllers
{
    [Edutor.Web.Common.UnitOfWorkActionFilter]
    public class StudentsController : ApiController
    {
        private readonly IPostStudentMaintenanceProcessor _addUserQueryProcessor;
        private readonly IGetStudentsInquiryProcessor _getStudentsInquiryProcessor;

        public StudentsController(IPostStudentMaintenanceProcessor addUserQueryProcessor, IGetStudentsInquiryProcessor getStudents)
        {
            _addUserQueryProcessor = addUserQueryProcessor;
            _getStudentsInquiryProcessor = getStudents;
        }


        /// <summary>
        /// Adds a new Tutor to the system
        /// </summary>
        /// <param name="newTutor">The tutor to be added</param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(Student))]
        public IHttpActionResult AddTutor(/*HttpRequestMessage requestMessage, */NewStudent newTutor)
        {

            var user = _addUserQueryProcessor.AddStudent(newTutor);
            var result = new ModelPostedActionResult<Student>(Request, user);
            return result;
        }

        [HttpGet]
        //[Authorize]
        [ResponseType(typeof(Student))]
        public Student GetStudentById(int id)
        {
            return _getStudentsInquiryProcessor.GetStudent(id);
        }

    }
}
