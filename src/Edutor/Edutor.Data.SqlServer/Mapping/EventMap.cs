using Edutor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.SqlServer.Mapping
{
    public class EventMap : VersionedClassMap<Event>
    {
        public EventMap()
        {
            Table("Events");
            Id(x => x.EventId);
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Date).Not.Nullable();
            Map(x => x.CreationDate).Not.Nullable();
            Map(x => x.Description).Not.Nullable();
            References<User>(x => x.SchoolUser).Column("SchoolUserId");

            // TODO Add references and mappings
        }
    }
}
