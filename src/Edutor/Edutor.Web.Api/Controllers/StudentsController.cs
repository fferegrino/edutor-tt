using Edutor.Web.Api.MaintenanceProcessing;
using Edutor.Web.Api.Models.NewModels;
using Edutor.Web.Api.QueryProcessing;
using System.Net.Http;
using System.Web.Http;

namespace Edutor.Web.Api.Controllers
{
    [Edutor.Web.Common.UnitOfWorkActionFilter]
    public class StudentsController : ApiController
    {
        private readonly IPostStudentMaintenanceProcessor _addUserQueryProcessor;
        //private readonly IGetSchoolUsersQueryProcessor _getQueryProcessor;

        public StudentsController(IPostStudentMaintenanceProcessor addUserQueryProcessor/*, IGetSchoolUsersQueryProcessor getQueryProcessor*/)
        {
            //_getQueryProcessor = getQueryProcessor;
            _addUserQueryProcessor = addUserQueryProcessor;
        }

        [HttpPost]
        public IHttpActionResult AddTutor(HttpRequestMessage requestMessage, NewStudent newStudent)
        {
            var user = _addUserQueryProcessor.AddStudent(newStudent);
            var result = new ModelPostedActionResult<NewStudent>(requestMessage, newStudent);
            return result;
        }
    }
}
