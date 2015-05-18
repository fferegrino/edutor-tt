using Edutor.Common.TypeMapping;
using Edutor.Data.Entities;
using Edutor.Data.QueryProcessors;
using Edutor.Web.Api.Models.NewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.UpdateProcessing
{
    public interface IPutNotificationsUpdateProcessor
    {
        void MarkAsSeen(NewSeenNotification nseen);
    }

    public class PutNotificationsUpdateProcessor : IPutNotificationsUpdateProcessor
    {
        private readonly IAutoMapper _mapper;
        private readonly IUpdateNotificationsQueryProcessor _updateNotifications;

        public PutNotificationsUpdateProcessor(IUpdateNotificationsQueryProcessor updateNotifications,
            IAutoMapper mapper)
        {
            _updateNotifications = updateNotifications;
            _mapper = mapper;
        }

        public void MarkAsSeen(NewSeenNotification newRsvp)
        {
            _updateNotifications.MarkAsSeen(_mapper.Map<NotificationDetail>(newRsvp));
        }
    }
}
