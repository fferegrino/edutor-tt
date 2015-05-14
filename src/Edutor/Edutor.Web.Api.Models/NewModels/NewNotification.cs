using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.NewModels
{
    public class NewNotification
    {
        public int SchoolUserId { get; set; }
        public int GroupId { get; set; }
        public string Text { get; set; }
    }
}
