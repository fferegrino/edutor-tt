using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.Entities
{
    public class SchoolUser : IVersionedEntity
    {

        public virtual char Position { get; set; }

        public virtual User User { get; set; }

        public virtual int SchoolUserId { get; set; }

        public virtual byte[] Version { get; set; }
    }
}
