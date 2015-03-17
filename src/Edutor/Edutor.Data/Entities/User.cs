using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.Entities
{
    public class User : IVersionedEntity
    {
        public virtual int UserId { get; set; }


        public virtual string Name { get; set; }

        
        public virtual string Curp { get; set; }


        public virtual string Email { get; set; }

        
        public virtual char Type { get; set; }

        
        public virtual string Address { get; set; }


        public virtual string Mobile { get; set; }


        public virtual string Telephone { get; set; }

        public virtual byte[] Version { get; set; }
    }
}
