using Edutor.Common;
using Edutor.Web.Api.InquiryProcessing;
using Edutor.Web.Api.MaintenanceProcessing;
using Edutor.Web.Api.Models;
using Edutor.Web.Api.Models.NewModels;
using Edutor.Web.Api.Models.ReturnTypes;
using Edutor.Web.Api.UpdateProcessing;
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
    /// Los extremos de notificaciones son los encargados de ofrecer la capacidad de crear y asignar las notificaciones a los usuarios 
    /// correspondientes. Al igual que la mayoría de los extremos dentro de Edutor, estos requieren de algún nivel de autenticación para 
    /// ser accedidos.
    /// </summary>
    [Edutor.Web.Common.UnitOfWorkActionFilter]
    public class NotificationsController : ApiController
    {
        private readonly IPostNotificationMaintenanceProcessor _notificationMaintenanceProcessor;
        private readonly IPutNotificationsUpdateProcessor _updateNotifications;
        private readonly IGetNotificationsInquiryProcessor _getNotifications;
        private readonly IGetStudentsInquiryProcessor _getStudents;
        private readonly IPagedDataRequestFactory _pagedDataRequestFactory;
        private readonly IDeleteInteracionsMaintenanceProcessor _deleteInteractions;

        public NotificationsController(IPostNotificationMaintenanceProcessor notificationMaintenanceProcessor,
            IGetNotificationsInquiryProcessor getNotifications,
             IGetStudentsInquiryProcessor getStudents,
            IPutNotificationsUpdateProcessor updateNotifications,
            IPagedDataRequestFactory pagedDataRequestFactory,
            IDeleteInteracionsMaintenanceProcessor deleteInteractions)
        {
            _deleteInteractions = deleteInteractions;
            _notificationMaintenanceProcessor = notificationMaintenanceProcessor;
            _getNotifications = getNotifications;
            _getStudents = getStudents;
            _pagedDataRequestFactory = pagedDataRequestFactory;
            _updateNotifications = updateNotifications;
        }

        /// <summary>
        /// Obtiene la notificación indicada por su identificador único, 
        /// Un usuario administrador podrá acceder a la información de todas las notificaciones, 
        /// mientras que cualquier otro usuario podrá acceder únicamente a las notificaciones que creó o de las que es receptor.
        /// </summary>
        /// <param name="notificationId">El identificador único de la notificación a obtener.</param>
        /// <returns>Devuelve la notificación deseada, en caso de que exista y el usuario tenga permiso para acceder a él.</returns>
        [HttpGet]
        [Route("notifications/{notificationId:int}")]
        [Authorize(Roles = Constants.RoleNames.All)]
        public Notification GetNotification(int notificationId)
        {
            return _getNotifications.GetNotification(notificationId);
        }

        /// <summary>
        /// Obtiene una lista paginada con los detalles de la notificación, 
        /// cada detalle consiste del identificador del estudiante notificado y el estatus de la notificación, 
        /// es decir, si el tutor ha visto o no la notificación.
        /// </summary>
        /// <param name="notificationId">El identificador único de la notificación que se desea obtener</param>
        /// <returns>Devuelve una lista paginada con los detalles de la notifcación</returns>
        [HttpGet]
        [ResponseType(typeof(PagedDataResponse<StudentNotification>))]
        [Route("notifications/{notificationId:int}/details")]
        [Authorize(Roles = Constants.RoleNames.SchoolUser)]
        public PagedDataResponse<StudentNotification> GetNotifiedUsers(int notificationId)
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            return _getStudents.GetStudentsForNotification(notificationId, request);
        }

        /// <summary>
        /// Obtienen el detalle de notificación indicado, cada detalle consiste del identificador del estudiante notificado y el estatus de la notificación, 
        /// es decir, si el tutor ha visto o no la notificación.
        /// </summary>
        /// <param name="notificationId">El identificador único de la notificación que se desea obtener</param>
        /// <param name="studentId">El identificador único del estudiante del que se desea obtener el detalle.</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(StudentNotification))]
        [Route("notifications/{notificationId:int}/details/{studentId:int}")]
        [Authorize(Roles = Constants.RoleNames.All)]
        public StudentNotification GetNotifiedUsers(int notificationId, int studentId)
        {
            return _getStudents.GetStudentsForNotification(notificationId, studentId);
        }

        /// <summary>
        /// Agrega una nueva notificación al sistema de acuerdo a la información enviáda en el cuerpo de la petición
        /// </summary>
        /// <param name="newNotification">La nueva notificación</param>
        /// <returns>La notificación agregada al sistema.</returns>
        [HttpPost]
        [ResponseType(typeof(Notification))]
        [Route("notifications")]
        [ValidationActionFilter]
        public IHttpActionResult AddNotification(NewNotification newNotification)
        {
            var user = _notificationMaintenanceProcessor.AddNotification(newNotification);
            var result = new ModelPostedActionResult<Notification>(Request, user);
            return result;
        }

        /// <summary>
        /// Marca la notificación como "vista" dentro del sistema
        /// </summary>
        /// <param name="notificationId">El identificador único de la notificación que se desea marcar como vista</param>
        /// <param name="studentId">El identificador único del estudiante que vió la notificación/param>
        /// <returns>Un código de estatus 204 (sin contenido) si la acción se realizó con éxito</returns>
        [HttpPut]
        [ResponseType(typeof(int))]
        [Route("notifications/{notificationId:int}/details/{studentId:int}")]
        [Authorize(Roles = Constants.RoleNames.Tutor)]
        public IHttpActionResult MarkNotificationAsSeen(int notificationId, int studentId)
        {
            _updateNotifications.MarkAsSeen(new NewSeenNotification { NotificationId = notificationId, StudentId = studentId });
            return new ModelDeletedActionResult(Request);
        }


        /// <summary>
        /// Elimina la notificación del sistema, 
        /// los detalles de notificación para los tutores también son eliminadas junto con la pregunta
        /// Esta acción solamente puede ser llevada a cabo por usuarios escolares.
        /// </summary>
        /// <param name="notificationId">El identificador único de la pregunta a eliminar.</param>
        /// <returns>Un código de estatus (No Content) si es que la acción se concluyó correctamente.</returns>
        [HttpDelete]
        [Authorize(Roles = Constants.RoleNames.SchoolUser)]
        [Route("notifications/{notificationId:int}")]
        public IHttpActionResult DeleteNotification(int notificationId)
        {
            _deleteInteractions.DeleteNotification(notificationId);
            return new ModelDeletedActionResult(Request);

        }
    }
}
