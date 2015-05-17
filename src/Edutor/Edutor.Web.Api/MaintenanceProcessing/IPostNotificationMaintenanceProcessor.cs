using Edutor.Common.TypeMapping;
using Edutor.Data.QueryProcessors;
using Edutor.Web.Api.LinkServices;
using Edutor.Web.Api.Models.NewModels;
using Ret = Edutor.Web.Api.Models.ReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.MaintenanceProcessing
{
    public interface IPostNotificationMaintenanceProcessor
    {
        Ret.Notification AddNotification(NewNotification notification);
    }

    public class PostNotificationMaintenanceProcessor : IPostNotificationMaintenanceProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly IAddNotificationQueryProcessor _addNotificationQueryProcessor;
        private readonly IAddNotificationDetailQueryProcessor _addNotificationDetailQueryProcessor;
        private readonly INotificationsLinkService _linkServices;

        public PostNotificationMaintenanceProcessor(IAutoMapper autoMapper,
            IAddNotificationQueryProcessor addUserQueryProcessor,
            IAddNotificationDetailQueryProcessor addInvitationsQueryProcessor,
            INotificationsLinkService linkServices)
        {
            _autoMapper = autoMapper;
            _addNotificationQueryProcessor = addUserQueryProcessor;
            _linkServices = linkServices;
            _addNotificationDetailQueryProcessor = addInvitationsQueryProcessor;
        }

        public Ret.Notification AddNotification(NewNotification notification)
        {
            var notificationEntity = _autoMapper.Map<Data.Entities.Notification>(notification);
            _addNotificationQueryProcessor.AddNotification(notificationEntity);
            var ret = _autoMapper.Map<Ret.Notification>(notificationEntity);

            var students = notificationEntity.Group.Students;

            var invitations = from s in students
                              select new Data.Entities.NotificationDetail
                              {
                                  NotificationId = notificationEntity.NotificationId,
                                  StudentId = s.StudentId
                              };
            _addNotificationDetailQueryProcessor.AddNotificationDetails(invitations.ToList());

            _linkServices.AddAllLinks(ret);

            return ret;
        }
    }
}
