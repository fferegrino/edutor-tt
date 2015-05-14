using Edutor.Web.Api.MaintenanceProcessing;
using Edutor.Web.Api.Models.NewModels;
//using Edutor.Web.Api.QueryProcessing;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Edutor.Web.Api.Controllers
{
    [Edutor.Web.Common.UnitOfWorkActionFilter]
    public class StudentsController : ApiController
    {
        private readonly IPostStudentMaintenanceProcessor _addUserQueryProcessor;

        public StudentsController(IPostStudentMaintenanceProcessor addUserQueryProcessor)
        {
            _addUserQueryProcessor = addUserQueryProcessor;
        }


        /// <summary>
        /// Adds a new Tutor to the system
        /// </summary>
        /// <param name="newTutor">The tutor to be added</param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(NewStudent))]
        public IHttpActionResult AddTutor(/*HttpRequestMessage requestMessage, */NewStudent newTutor)
        {

            var user = _addUserQueryProcessor.AddStudent(newTutor);
            var result = new ModelPostedActionResult<NewStudent>(Request, newTutor);
            return result;
        }

    }
}
