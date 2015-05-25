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
    /// Conjunto de extremos REST que permiten operar con los servicios de creación y manipulación de notificaciones que ofrece la plataforma
    /// </summary>
    [Edutor.Web.Common.UnitOfWorkActionFilter]
    public class NotificationsController : ApiController
    {
        private readonly IPostNotificationMaintenanceProcessor _notificationMaintenanceProcessor;
        private readonly IPutNotificationsUpdateProcessor _updateNotifications;
        private readonly IGetNotificationsInquiryProcessor _getNotifications;
        private readonly IGetStudentsInquiryProcessor _getStudents;
        private readonly IPagedDataRequestFactory _pagedDataRequestFactory;

        public NotificationsController(IPostNotificationMaintenanceProcessor notificationMaintenanceProcessor,
            IGetNotificationsInquiryProcessor getNotifications,
             IGetStudentsInquiryProcessor getStudents,
            IPutNotificationsUpdateProcessor updateNotifications,
            IPagedDataRequestFactory pagedDataRequestFactory)
        {
            _notificationMaintenanceProcessor = notificationMaintenanceProcessor;
            _getNotifications = getNotifications;
            _getStudents = getStudents;
            _pagedDataRequestFactory = pagedDataRequestFactory;
            _updateNotifications = updateNotifications;
        }

        /// <summary>
        /// Regresa la notificación solicitada mediante la URL
        /// </summary>
        /// <param name="notificationId">El identificador único de la notificación deseada</param>
        /// <returns></returns>
        [HttpGet]
        [Route("notifications/{notificationId:int}")]
        [Authorize(Roles = Constants.RoleNames.All)]
        public Notification GetNotification(int notificationId)
        {
            return _getNotifications.GetNotification(notificationId);
        }

        /// <summary>
        /// Regesa una lista paginada con los detalles de la notificación
        /// </summary>
        /// <param name="notificationId">El identificador único de la notificación que se desea obtener</param>
        /// <returns></returns>
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
        /// Obtienen el detalle de notifricación indicado
        /// </summary>
        /// <param name="notificationId">El identificador único de la notificación que se desea obtener</param>
        /// <param name="studentId">El identificador único del estudiante con la notificación</param>
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
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(Notification))]
        [Route("notifications")]
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
        /// <returns></returns>
        [HttpPut]
        [ResponseType(typeof(int))]
        [Route("notifications/{notificationId:int}/details/{studentId:int}")]
        [Authorize(Roles = Constants.RoleNames.Tutor)]
        public int MarkNotificationAsSeen(int notificationId, int studentId)
        {
            _updateNotifications.MarkAsSeen(new NewSeenNotification { NotificationId = notificationId, StudentId = studentId });
            return 0;
        }
    }
}
