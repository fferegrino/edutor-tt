using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.ReturnTypes
{
    public class BasicStudent : LinkContaining
    {

        public int StudentId { get; set; }
        public string Curp { get; set; }
        public string Name { get; set; }
        //public string Token { get; set; }

    }
}
