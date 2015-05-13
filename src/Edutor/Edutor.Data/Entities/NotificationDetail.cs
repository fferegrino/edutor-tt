using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.Entities
{
    public class NotificationDetail : IVersionedEntity
    {
        public virtual int StudentId { get; set; }
        public virtual int NotificationId { get; set; }
        public virtual bool Seen { get; set; }

        public virtual Notification Notification { get; set; }
        public virtual Student Student { get; set; }

        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            NotificationDetail p = obj as NotificationDetail;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (NotificationId == p.NotificationId) && (StudentId == p.StudentId);
        }

        public override int GetHashCode()
        {
            return NotificationId ^ StudentId;
        }

        public virtual byte[] Version { get; set; }
    }
}
