using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.ReturnTypes
{
    public class StudentInvitation : Student
    {
        public int EventId { get; set; }
        public int GroupId { get; set; }
        public int SchoolUserId { get; set; }
        public string EventName { get; set; }
        public bool? Rsvp { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
    }
}
