using Edutor.Web.Api.MaintenanceProcessing;
using Edutor.Web.Api.Models.NewModels;
using Edutor.Web.Api.Models.ReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Edutor.Web.Api.Controllers
{
    [Edutor.Web.Common.UnitOfWorkActionFilter]
    public class ConversationsController : ApiController
    {
        /// <summary>
        /// Agrega un nuevo tutor al sistema
        /// </summary>
        /// <param name="newTutor">El nuevo tutor a ingresar</param>
        /// <returns></returns>
        [HttpPost]
        [Route("conversations/messages")]
        [ResponseType(typeof(Message))]
        public IHttpActionResult AddTutor(NewMessage newMessage)
        {
            //var user = _addUserQueryProcessor.AddUser(newTutor);
            var result = new ModelPostedActionResult<Message>(Request, null);
            return result;
        }
    }
}
