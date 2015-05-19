using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.ReturnTypes
{
    public class Message : LinkContaining
    {
        public int ConversationId { get; set; }
        public int MessageId { get; set; }
        public int ToId { get; set; }
        public int FromId { get; set; }
        public string Text { get; set; }
        public DateTime SentDate { get; set; }
        public DateTime? SeenDate { get; set; }
    }
}
