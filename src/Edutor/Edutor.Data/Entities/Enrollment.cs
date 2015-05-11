using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.Entities
{
    public class Enrollment : IVersionedEntity
    {
        public virtual int GroupId { get; set; }
        public virtual int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public virtual Group Group { get; set; }
        public virtual byte[] Version { get; set; }


        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Enrollment p = obj as Enrollment;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (GroupId == p.GroupId) && (StudentId == p.StudentId);
        }

        public override int GetHashCode()
        {
            return GroupId ^ StudentId;
        }
    }
}
