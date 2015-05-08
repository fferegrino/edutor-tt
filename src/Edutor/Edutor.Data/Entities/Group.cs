using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.Entities
{
    public class Group : IVersionedEntity
    {
        public virtual int GroupId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Subject { get; set; }
        public virtual DateTime From { get; set; }
        public virtual DateTime? To { get; set; }
        public virtual byte[] Version { get; set; }
    }
}
