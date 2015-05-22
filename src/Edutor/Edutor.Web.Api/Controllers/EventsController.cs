using Edutor.Common;
using Edutor.Web.Api.InquiryProcessing;
using Edutor.Web.Api.MaintenanceProcessing;
using Edutor.Web.Api.Models;
using Edutor.Web.Api.Models.NewModels;
using Edutor.Web.Api.Models.ReturnTypes;
using Edutor.Web.Api.UpdateProcessing;
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
    /// Conjunto de extremos REST que permiten operar con los servicios de creación y manipulación de eventos que ofrece la plataforma
    /// </summary>
    [Edutor.Web.Common.UnitOfWorkActionFilter]
    public class EventsController : ApiController
    {
        private readonly IPostEventMaintenanceProcessor _addQueryProcessor;
        private readonly IGetStudentsInquiryProcessor _getStudents;
        private readonly IGetEventsInquiryProcessor _getEvents;
        private readonly IPutEventsUpdateProcessor _updateEvents;
        private readonly IPagedDataRequestFactory _pagedDataRequestFactory;

        public EventsController(IPostEventMaintenanceProcessor addQueryProcessor,
            IGetEventsInquiryProcessor getEvents,
            IPutEventsUpdateProcessor updateEvents,
            IPagedDataRequestFactory pagedDataRequestFactory,
            IGetStudentsInquiryProcessor getStudents)
        {
            _getEvents = getEvents;
            _addQueryProcessor = addQueryProcessor;
            _pagedDataRequestFactory = pagedDataRequestFactory;
            _getStudents = getStudents;
            _updateEvents = updateEvents;
        }
        /// <summary>
        /// Agrega un evento al sistema
        /// </summary>
        /// <param name="newEvent">El nuevo evento</param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(Event))]
        [Route("events")]
        public IHttpActionResult AddEvent(NewEvent newEvent)
        {
            var user = _addQueryProcessor.AddEvent(newEvent);
            var result = new ModelPostedActionResult<Event>(Request, user);
            return result;
        }


        /// <summary>
        /// Obtiene el evento indicado
        /// </summary>
        /// <param name="eventId">El identificador único del evento que se desea obtener</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(Event))]
        [Route("events/{eventId:int}")]
        public Event GetEvent(int eventId)
        {
            return _getEvents.GetEvent(eventId);
        }

        /// <summary>
        /// Obtiene el una lista de los estudiantes invitados al evento indicado
        /// </summary>
        /// <param name="eventId">El identificador único del evento que se desea obtener</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(PagedDataInquiryResponse<StudentInvitation>))]
        [Route("events/{eventId:int}/attendees")]
        public PagedDataInquiryResponse<StudentInvitation> GetEventAttendees(int eventId)
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            return _getStudents.GetStudentsForEvent(eventId, request);
        }

        /// <summary>
        /// Obtiene la invitación del estudiante indicado al evento
        /// </summary>
        /// <param name="eventId">El identificador único del evento que se desea obtener</param>
        /// <param name="studentId">El identificador único del estudiante deseado</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(StudentInvitation))]
        [Route("events/{eventId:int}/attendees/{studentId:int}")]
        public StudentInvitation GetEventAttendees(int eventId, int studentId)
        {
            return _getStudents.GetStudentsForEvent(eventId, studentId);
        }

        /// <summary>
        /// Indica si se asistirá al evento
        /// </summary>
        /// <param name="eventId">El identificador único del evento que se desea responder</param>
        /// <param name="studentId">El identificador único del estudiante que responde</param>
        /// <returns></returns>
        [HttpPut]
        [ResponseType(typeof(int))]
        [Route("events/{eventId:int}/attendees/{studentId:int}")]
        public int GetEventAttendees(int eventId, int studentId, NewRsvp rsvp)
        {
            rsvp.EventId = eventId;
            rsvp.StudentId = studentId;
            _updateEvents.Rsvp(rsvp);
            return 0;
        }


    }
}