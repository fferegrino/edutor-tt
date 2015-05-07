using Edutor.Web.Api.MaintenanceProcessing;
using Edutor.Web.Api.Models;
using Edutor.Web.Api.Models.NewModels;
using Edutor.Web.Api.QueryProcessing;
using Edutor.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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

        [HttpPost]
        public IHttpActionResult AddTutor(HttpRequestMessage requestMessage, NewTutor newUser)
        {
            var user = _addUserQueryProcessor.AddUser(newUser);
            var result = new ModelPostedActionResult<NewTutor>(requestMessage, user);
            return result;
        }
    }
}
