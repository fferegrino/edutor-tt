using Edutor.Common;
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
    /// <summary>
    /// Controlador de eventos dentro de la plataforma Edutor
    /// </summary>
    [Edutor.Web.Common.UnitOfWorkActionFilter]
    public class EventsController : ApiController
    {
        private readonly IPostEventMaintenanceProcessor _addQueryProcessor;

        public EventsController(IPostEventMaintenanceProcessor addQueryProcessor)
        {
            _addQueryProcessor = addQueryProcessor;
        }


        /// <summary>
        /// Agrega un evento al sistema
        /// </summary>
        /// <param name="newEvent">El nuevo evento</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = Constants.RoleNames.Teacher)]
        [ResponseType(typeof(Event))]
        public IHttpActionResult AddTutor(NewEvent newEvent)
        {
            var user = _addQueryProcessor.AddEvent(newEvent);
            var result = new ModelPostedActionResult<Event>(Request, user);
            return result;
        }
    }
}
