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

        public virtual Event Event { get; set; }
        public virtual Student Student { get; set; }

        public virtual byte[] Version { get; set; }
    }
}
