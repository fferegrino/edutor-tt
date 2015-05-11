using System;
using System.Collections.Generic;

namespace Edutor.Data.Entities
{
    public class Group : IVersionedEntity
    {
        public virtual int GroupId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Subject { get; set; }
        public virtual DateTime FromDate { get; set; }
        public virtual DateTime? ToDate { get; set; }

        public virtual IList<User> Teachers { get; set; }
        public virtual IList<Student> Students { get; set; }

        public virtual byte[] Version { get; set; }
    }
}
