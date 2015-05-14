using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.QueryProcessors
{
    public interface IAddNotificationQueryProcessor
    {
        void AddNotification(Data.Entities.Notification notification);
    }
}
