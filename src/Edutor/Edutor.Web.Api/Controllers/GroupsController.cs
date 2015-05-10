using Edutor.Web.Api.MaintenanceProcessing;
using Edutor.Web.Api.Models.NewModels;
using Edutor.Web.Api.QueryProcessing;
using System.Net.Http;
using System.Web.Http;

namespace Edutor.Web.Api.Controllers
{
    [Edutor.Web.Common.UnitOfWorkActionFilter]
    public class GroupsController : ApiController
    {

        private readonly IPostGroupMaintenanceProcessor _addUserQueryProcessor;

        public GroupsController(IPostGroupMaintenanceProcessor addUserQueryProcessor)
        {
            _addUserQueryProcessor = addUserQueryProcessor;
        }



        [HttpPost]
        public IHttpActionResult AddGroup(HttpRequestMessage requestMessage, NewGroup newUser)
        {
            var user = _addUserQueryProcessor.AddGroup(newUser);
            var result = new ModelPostedActionResult<NewGroup>(requestMessage, user);
            return result;
        }
    }
}
