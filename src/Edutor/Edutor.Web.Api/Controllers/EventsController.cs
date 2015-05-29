using Edutor.Common;
using Edutor.Web.Api.InquiryProcessing;
using Edutor.Web.Api.MaintenanceProcessing;
using Edutor.Web.Api.Models;
using Edutor.Web.Api.Models.NewModels;
using Edutor.Web.Api.Models.ReturnTypes;
using Edutor.Web.Api.UpdateProcessing;
using Edutor.Web.Common;
using Edutor.Web.Common.Filters;
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
    /// Los extremos de eventos permiten la planeación de eventos escolares, 
    /// son los usuarios escolares los encargados de crear los eventos mientras que los tutores los encargados de
    /// confirmar o negar su asistencia a los mismos.
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
        /// Obtiene el evento indicado por el identificador único,
        /// un usuario administrador podrá recuperar cualquier evento, 
        /// mientras que cualquier otro usuario solo podrá recuperar los eventos de los que es participante.
        /// </summary>
        /// <param name="eventId">El identificador único del evento que se desea obtener, debe ser un entero mayor a 0.</param>
        /// <returns>Devuelve la conversación deseada, en caso de que exista y el usuario tenga permiso para acceder a ella.</returns>
        [Route("events/{eventId:int}")]
        [HttpGet]
        [ResponseType(typeof(Event))]
        [Authorize(Roles = Constants.RoleNames.All)]
        public Event GetEvent(int eventId)
        {
            return _getEvents.GetEvent(eventId);
        }

        /// <summary>
        /// Obtiene una lista paginada de los estudiantes invitados y su estatus respecto al evento.
        /// A este extremo sólamente pueden acceder usuarios escolares, 
        /// los administradores pueden recuperar los invitados de cualquier evento mientras que cualquier otro solo puede
        /// acceder a la lista de invitados a eventos que ha creado.
        /// </summary>
        /// <param name="eventId">El identificador único del evento que se desea obtener la lista de invitados.</param>
        /// <returns>La lista de invitados deseada, en caso de que exista y el usuario tenga permiso para acceder a ella.</returns>
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
        /// Obtiene la invitación del estudiante al evento indicado.
        /// Esta acción es solo accesible para el usuario tutor del estudiante invitado.
        /// </summary>
        /// <param name="eventId">El identificador único del evento que se desea obtener</param>
        /// <param name="studentId">El identificador único del estudiante deseado</param>
        /// <returns>Regresa la invitación del estudiante indicado al evento, 
        /// en caso de que exista y el usuario tenga permisos para acceder a ella</returns>
        [Route("events/{eventId:int}/attendees/{studentId:int}")]
        [HttpGet]
        [ResponseType(typeof(StudentInvitation))]
        [Authorize(Roles = Constants.RoleNames.Tutor)]
        public StudentInvitation GetEventAttendee(int eventId, int studentId)
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
        public IHttpActionResult ConfirmAttendance(int eventId, int studentId, NewRsvp rsvp)
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
        [Authorize(Roles = Constants.RoleNames.SchoolUser)]
        [ValidationActionFilter]
        public IHttpActionResult AddEvent(NewEvent newEvent)
        {
            var user = _addQueryProcessor.AddEvent(newEvent);
            var result = new ModelPostedActionResult<Event>(Request, user);
            return result;
        }


    }
}