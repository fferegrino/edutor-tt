using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.ReturnTypes
{
    public class Event : LinkContaining
    {
        public int EventId { get; set; }
        public int SchoolUserId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
    }
}
