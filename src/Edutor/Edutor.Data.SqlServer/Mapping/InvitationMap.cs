using Edutor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.SqlServer.Mapping
{
    public class InvitationMap : VersionedClassMap<Invitation>
    {
        public InvitationMap()
        {
            Table("Invitations");
            Map(x => x.Rsvp);
            CompositeId().KeyReference(l => l.Student, "StudentId").KeyReference(l => l.Event, "EventId");
            //References<Event>(x => x.Event).Column("EventId");
            //References<Student>(x => x.Student).Column("StudentId");
        }
    }
}
