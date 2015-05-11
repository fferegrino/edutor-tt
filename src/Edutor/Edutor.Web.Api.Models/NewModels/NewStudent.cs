using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.NewModels
{
    public class NewStudent : LinkContaining
    {

        public int StudentId { get; set; }
        public int TutorId { get; set; }
        public string TutorRelationship { get; set; }
        //public bool IsActive { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Curp { get; set; }
        public string Name { get; set; }
        //public string Token { get; set; }

    }
}
