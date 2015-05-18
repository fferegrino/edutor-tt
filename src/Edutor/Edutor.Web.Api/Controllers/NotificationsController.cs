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
        [ResponseType(typeof(PagedDataInquiryResponse<StudentNotification>))]
        [Route("notifications/{notificationId:int}/details")]
        public PagedDataInquiryResponse<StudentNotification> GetNotifiedUsers(int notificationId)
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            return _getStudents.GetStudentsForNotification(notificationId, request);
        }

        /// <summary>
        /// Obtienen el detalle de notifricación indicado
        /// </summary>
        /// <param name="notificationId">El id de la notificación que se desea obtener</param>
        /// <param name="studentId">El id del estudiante con la notificación</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(StudentNotification))]
        [Route("notifications/{notificationId:int}/details/{studentId:int}")]
        public StudentNotification GetNotifiedUsers(int notificationId, int studentId)
        {
            return _getStudents.GetStudentsForNotification(notificationId, studentId);
        }

        /// <summary>
        /// Una simple llamada a este extremo ocasionará que la notificación sea marcada como vista
        /// </summary>
        /// <param name="notificationId">El id de la notificación que se desea marcar como vista</param>
        /// <param name="studentId">El id del estudiante que vió la notificación/param>
        /// <returns></returns>
        [HttpPut]
        [ResponseType(typeof(int))]
        [Route("notifications/{notificationId:int}/details/{studentId:int}")]
        public int MarkNotificationAsSeen(int notificationId, int studentId)
        {
            _updateNotifications.MarkAsSeen(new NewSeenNotification { NotificationId = notificationId, StudentId = studentId });
            return 0;
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
