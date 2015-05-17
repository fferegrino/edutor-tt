using Edutor.Web.Api.InquiryProcessing;
using Edutor.Web.Api.MaintenanceProcessing;
using Edutor.Web.Api.Models;
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
    public class NotificationsController : ApiController
    {
        private readonly IPostNotificationMaintenanceProcessor _notificationMaintenanceProcessor;
        private readonly IGetNotificationsInquiryProcessor _getNotifications;
        private readonly IGetStudentsInquiryProcessor _getStudentsInquiryProcessor;

        public NotificationsController(IPostNotificationMaintenanceProcessor notificationMaintenanceProcessor,
            IGetNotificationsInquiryProcessor getNotifications)
        {
            _notificationMaintenanceProcessor = notificationMaintenanceProcessor;
            _getNotifications = getNotifications;
        }

        /// <summary>
        /// Obtiene la notificación indicada
        /// </summary>
        /// <param name="notificationId">El id de la notificación deseada</param>
        /// <returns></returns>
        [HttpGet]
        public Notification GetNotification(int notificationId)
        {
            return _getNotifications.GetNotification(notificationId);
        }

        /// <summary>
        /// Agrega una nueva notificación al sistema
        /// </summary>
        /// <param name="newNotification">La nueva notificación</param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(Notification))]
        public IHttpActionResult AddNotification(NewNotification newNotification)
        {
            var user = _notificationMaintenanceProcessor.AddNotification(newNotification);
            var result = new ModelPostedActionResult<Notification>(Request, user);
            return result;
        }
    }
}
