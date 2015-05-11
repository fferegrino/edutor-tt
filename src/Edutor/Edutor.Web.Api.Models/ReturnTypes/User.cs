using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.ReturnTypes
{
    public class User : LinkContaining
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Curp { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public char Type { get; set; }
    }
}
