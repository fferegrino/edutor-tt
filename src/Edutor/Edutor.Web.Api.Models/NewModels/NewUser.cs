using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.NewModels
{
    public class NewUser
    {
        public virtual string Name { get; set; }


        public virtual string Curp { get; set; }


        public virtual string Email { get; set; }


        //public virtual char Type { get; set; }


        public virtual string Address { get; set; }


        public virtual string Mobile { get; set; }


        public virtual string Telephone { get; set; }
    }
}
