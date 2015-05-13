using Edutor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.SqlServer.Mapping
{
    public class NotificationDetailMap : VersionedClassMap<NotificationDetail>
    {
        public NotificationDetailMap()
        {
            Table("NotificationDetails");
            Map(x => x.Seen);
            CompositeId().KeyReference(l => l.Student, "StudentId").KeyReference(l => l.Notification, "NotificationId");
        }
    }
}
