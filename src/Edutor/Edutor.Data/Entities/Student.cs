using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.Entities
{
    public class Student : IVersionedEntity
    {
        public virtual int StudentId { get; set; }
        public virtual int TutorId { get; set; }
        public virtual string TutorRelationship { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string Address { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Curp { get; set; }
        public virtual string Name { get; set; }
        public virtual string Token { get; set; }

        public virtual User Tutor { get; set; }

        public virtual IList<Group> Groups { get; set; }


        public virtual byte[] Version { get; set; }
    }
}
