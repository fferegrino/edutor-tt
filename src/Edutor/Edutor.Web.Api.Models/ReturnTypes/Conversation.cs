using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.ReturnTypes
{
    public class Conversation : LinkContaining
    {
        public int ConversationId { get; set; }
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public int RecipientId { get; set; }

        public string RecipientName { get; set; }

        public IList<Message> LastMessages { get; set; }
    }
}
