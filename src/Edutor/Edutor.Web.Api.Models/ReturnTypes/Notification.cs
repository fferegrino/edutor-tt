using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.ReturnTypes
{
    public class Notification : LinkContaining
    {
        public int NotificationId { get; set; }
        public int SchoolUserId { get; set; }
        public int GroupId { get; set; }
        public string Text { get; set; }
    }
}
