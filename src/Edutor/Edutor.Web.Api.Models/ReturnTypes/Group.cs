using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.ReturnTypes
{
    public class Group : LinkContaining
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int StudentsCount { get; set; }
        public int TeachersCount { get; set; }
    }
}
