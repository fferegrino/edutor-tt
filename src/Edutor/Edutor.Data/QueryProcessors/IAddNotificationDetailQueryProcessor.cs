using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.QueryProcessors
{
    public interface IAddNotificationDetailQueryProcessor
    {
        void AddNotificationDetail(Data.Entities.NotificationDetail notificationDetail);

        void AddNotificationDetails(IList<Data.Entities.NotificationDetail> notificationDetails);
    }
}
