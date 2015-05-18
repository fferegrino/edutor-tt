using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.NewModels
{
    public class NewRsvp
    {
        public bool Rsvp { get; set; }
        public int StudentId { get; set; }
        public int EventId { get; set; }

    }
}
