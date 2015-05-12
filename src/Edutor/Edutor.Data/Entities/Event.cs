using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.Entities
{
    public class Event : IVersionedEntity
    {
        public virtual int EventId { get; set; }
        public virtual int SchoolUserId { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual string Description { get; set; }

        public virtual User SchoolUser { get; set; }
        public virtual byte[] Version { get; set; }
    }
}
