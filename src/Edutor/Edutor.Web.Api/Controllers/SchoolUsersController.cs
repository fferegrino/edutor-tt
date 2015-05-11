using Edutor.Data.QueryProcessors;
using Edutor.Web.Api.MaintenanceProcessing;
using Edutor.Web.Api.Models;
using Edutor.Web.Api.Models.NewModels;
using Edutor.Web.Api.Models.ReturnTypes;
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
    [UnitOfWorkActionFilter]
    public class SchoolUsersController : ApiController
    {
        private readonly IPostSchoolUserMaintenanceProcessor _addUserQueryProcessor;
        private readonly IGetSchoolUsersQueryProcessor _getQueryProcessor;

        public SchoolUsersController(IPostSchoolUserMaintenanceProcessor addUserQueryProcessor, IGetSchoolUsersQueryProcessor getQueryProcessor)
        {
            _getQueryProcessor = getQueryProcessor;
            _addUserQueryProcessor = addUserQueryProcessor;
        }

        [HttpGet]
        public SchoolUser GetSchoolUser(int id)
        {
            return _getQueryProcessor.GetById(id);
        }

        [HttpPost]
        public IHttpActionResult AddSchoolUser(HttpRequestMessage requestMessage, NewSchoolUser newUser)
        {
            var user = _addUserQueryProcessor.AddUser(newUser);
            var result = new ModelPostedActionResult<SchoolUser>(requestMessage, user);
            return result;
        }
    }
}
