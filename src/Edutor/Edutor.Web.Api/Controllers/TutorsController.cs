using Edutor.Web.Api.MaintenanceProcessing;
using Edutor.Web.Api.Models.NewModels;
using Edutor.Web.Api.Models.ReturnTypes;
using Edutor.Web.Api.QueryProcessing;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Edutor.Web.Api.Controllers
{
    [Edutor.Web.Common.UnitOfWorkActionFilter]
    public class TutorsController : ApiController
    {
        private readonly IPostTutorMaintenanceProcessor _addUserQueryProcessor;
        private readonly IGetSchoolUsersQueryProcessor _getQueryProcessor;

        public TutorsController(IPostTutorMaintenanceProcessor addUserQueryProcessor, IGetSchoolUsersQueryProcessor getQueryProcessor)
        {
            _getQueryProcessor = getQueryProcessor;
            _addUserQueryProcessor = addUserQueryProcessor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(Tutor))]
        public IHttpActionResult AddTutor(NewTutor newUser)
        {
            var user = _addUserQueryProcessor.AddUser(newUser);
            var result = new ModelPostedActionResult<Tutor>(Request, user);
            return result;
        }
    }
}
