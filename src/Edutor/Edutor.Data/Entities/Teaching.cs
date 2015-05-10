using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.Entities
{
    public class Teaching : IVersionedEntity
    {
        public int GroupId { get; set; }
        public int SchoolUserId { get; set; }
    
    
        public byte[] Version { get; set; }
    }
}
