using Edutor.Data.QueryProcessors;
using Edutor.Web.Api.MaintenanceProcessing;
using Edutor.Web.Api.Models;
using Edutor.Web.Api.Models.NewModels;
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
    public class UsersController : ApiController
    {
        private readonly IAddUserMaintenanceProcessor _addUserQueryProcessor;

        public UsersController(IAddUserMaintenanceProcessor addUserQueryProcessor)
        {
            _addUserQueryProcessor = addUserQueryProcessor;
        }

        [HttpGet]
        public int GetUser(int id)
        {
            return id;
        }

        [HttpPost]
        public IHttpActionResult AddUser(HttpRequestMessage requestMessage, NewUser newUser)
        {
            var user = _addUserQueryProcessor.AddUser(newUser);
            var result = new ModelCreatedActionResult<User>(requestMessage, user);
            return result;
        }
    }
}
