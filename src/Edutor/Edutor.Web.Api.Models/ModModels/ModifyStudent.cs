using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.ModModels
{
    public class ModifyStudent
    {
        public int StudentId { get; set; }
        public string TutorRelationship { get; set; }
        public int StudentId { get; set; }
        public int TutorId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
    }
}
