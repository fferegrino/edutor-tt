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
        private readonly IGetStudentsInquiryProcessor _getStudents;
        private readonly IPagedDataRequestFactory _pagedDataRequestFactory;

        public NotificationsController(IPostNotificationMaintenanceProcessor notificationMaintenanceProcessor,
            IGetNotificationsInquiryProcessor getNotifications,
             IGetStudentsInquiryProcessor getStudents,
            IPagedDataRequestFactory pagedDataRequestFactory)
        {
            _notificationMaintenanceProcessor = notificationMaintenanceProcessor;
            _getNotifications = getNotifications;
            _getStudents = getStudents;
            _pagedDataRequestFactory = pagedDataRequestFactory;
        }

        /// <summary>
        /// Obtiene la notificación indicada
        /// </summary>
        /// <param name="notificationId">El id de la notificación deseada</param>
        /// <returns></returns>
        [HttpGet]
        [Route("notifications/{notificationId:int}")]
        public Notification GetNotification(int notificationId)
        {
            return _getNotifications.GetNotification(notificationId);
        }
        
        /// <summary>
        /// Obtiene el una lista de los estudiantes notificados
        /// </summary>
        /// <param name="notificationId">El id de la notificación que se desea obtener</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(PagedDataInquiryResponse<Student>))]
        [Route("events/{notificationId:int}/notified")]
        public PagedDataInquiryResponse<Student> GetNotifiedUsers(int notificationId)
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            return _getStudents.GetStudentsForNotification(notificationId, request);
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
