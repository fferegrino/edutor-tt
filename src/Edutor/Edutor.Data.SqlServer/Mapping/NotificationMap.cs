using Edutor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.SqlServer.Mapping
{
    public class NotificationMap : VersionedClassMap<Notification>
    {
        public NotificationMap()
        {
            Table("Notifications");
            Id(x => x.NotificationId);
            Map(x => x.Text).Not.Nullable();
            Map(x => x.CreationDate).Not.Nullable();
            HasMany<NotificationDetail>(ev => ev.Details).KeyColumn("NotificationId").Cascade.AllDeleteOrphan().Inverse();
            References<User>(x => x.SchoolUser).Column("SchoolUserId");
            References<Group>(x => x.Group).Column("GroupId");

            // TODO Add references and mappings
        }
    }
}
