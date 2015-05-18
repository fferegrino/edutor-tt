using Edutor.Common;
using Edutor.Web.Api.InquiryProcessing;
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
        private readonly IGetEventsInquiryProcessor _getEvents;

        public EventsController(IPostEventMaintenanceProcessor addQueryProcessor,
            IGetEventsInquiryProcessor getEvents)
        {
            _getEvents = getEvents;
            _addQueryProcessor = addQueryProcessor;
        }

        /// <summary>
        /// Obtiene el evento indicado
        /// </summary>
        /// <param name="eventId">El id del evento que se desea obtener</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(Event))]
        [Route("events/{eventId:int}")]
        public Event GetEvent(int eventId)
        {
            return _getEvents.GetEvent(eventId);

        }


        /// <summary>
        /// Agrega un evento al sistema
        /// </summary>
        /// <param name="newEvent">El nuevo evento</param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(Event))]
        public IHttpActionResult AddEvent(NewEvent newEvent)
        {
            var user = _addQueryProcessor.AddEvent(newEvent);
            var result = new ModelPostedActionResult<Event>(Request, user);
            return result;
        }
    }
}
