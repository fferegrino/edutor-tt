using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.Entities
{
    public class Invitation : IVersionedEntity
    {
        public virtual int StudentId { get; set; }
        public virtual int EventId { get; set; }
        public virtual bool? Rsvp { get; set; }

        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Invitation p = obj as Invitation;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (EventId == p.EventId) && (StudentId == p.StudentId);
        }

        public override int GetHashCode()
        {
            return EventId ^ StudentId;
        }

        public virtual Event Event { get; set; }
        public virtual Student Student { get; set; }

        public virtual byte[] Version { get; set; }
    }
}
