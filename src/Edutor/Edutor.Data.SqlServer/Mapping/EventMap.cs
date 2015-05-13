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
            References<Group>(x => x.Group).Column("GroupId");

            // TODO Add references and mappings
        }
    }

    public class InvitationMap :VersionedClassMap<Invitation>
    {
        public InvitationMap()
        {
            Table("Invitations");
            Map(i => i.Rsvp);
            CompositeId().KeyReference(l => l.Student, "StudentId");
            CompositeId().KeyReference(l => l.Event, "EventId");
        }
    }
}
