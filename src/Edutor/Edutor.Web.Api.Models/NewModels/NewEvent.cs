using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.NewModels
{
    public class NewEvent
    {
        public int SchoolUserId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int EventId { get; set; }
    }
}
