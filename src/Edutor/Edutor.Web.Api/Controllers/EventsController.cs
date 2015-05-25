using Edutor.Common;
using Edutor.Web.Api.InquiryProcessing;
using Edutor.Web.Api.MaintenanceProcessing;
using Edutor.Web.Api.Models;
using Edutor.Web.Api.Models.NewModels;
using Edutor.Web.Api.Models.ReturnTypes;
using Edutor.Web.Api.UpdateProcessing;
using Edutor.Web.Common;
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
    [UnitOfWorkActionFilter]
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
        /// Obtiene el evento indicado
        /// </summary>
        /// <param name="eventId">El identificador único del evento que se desea obtener</param>
        /// <returns></returns>
        [Route("events/{eventId:int}")]
        [HttpGet]
        [ResponseType(typeof(Event))]
        [Authorize(Roles = Constants.RoleNames.All)]
        public Event GetEvent(int eventId)
        {
            return _getEvents.GetEvent(eventId);
        }

        /// <summary>
        /// Obtiene el una lista de los estudiantes invitados al evento indicado
        /// </summary>
        /// <param name="eventId">El identificador único del evento que se desea obtener</param>
        /// <returns></returns>
        [Route("events/{eventId:int}/attendees")]
        [HttpGet]
        [ResponseType(typeof(PagedDataResponse<StudentInvitation>))]
        [Authorize(Roles = Constants.RoleNames.SchoolUser)]
        public PagedDataResponse<StudentInvitation> GetEventAttendees(int eventId)
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
        [Route("events/{eventId:int}/attendees/{studentId:int}")]
        [HttpGet]
        [ResponseType(typeof(StudentInvitation))]
        [Authorize(Roles = Constants.RoleNames.Tutor)]
        public StudentInvitation GetEventAttendees(int eventId, int studentId)
        {
            return _getStudents.GetStudentsForEvent(eventId, studentId);
        }

        /// <summary>
        /// Indica si se asistirá al evento o no
        /// </summary>
        /// <param name="eventId">El identificador único del evento que se desea responder</param>
        /// <param name="studentId">El identificador único del estudiante que responde</param>
        /// <returns></returns>
        [Route("events/{eventId:int}/attendees/{studentId:int}")]
        [HttpPut]
        [Authorize(Roles = Constants.RoleNames.Tutor)]
        public IHttpActionResult GetEventAttendees(int eventId, int studentId, NewRsvp rsvp)
        {
            rsvp.EventId = eventId;
            rsvp.StudentId = studentId;
            _updateEvents.Rsvp(rsvp);
            return new ModelDeletedActionResult(Request);
        }

        /// <summary>
        /// Agrega un evento al sistema
        /// </summary>
        /// <param name="newEvent">El nuevo evento</param>
        /// <returns></returns>
        [Route("events")]
        [HttpPost]
        [ResponseType(typeof(Event))]
        [Authorize(Roles = Constants.RoleNames.Administrator)]
        public IHttpActionResult AddEvent(NewEvent newEvent)
        {
            var user = _addQueryProcessor.AddEvent(newEvent);
            var result = new ModelPostedActionResult<Event>(Request, user);
            return result;
        }


    }
}