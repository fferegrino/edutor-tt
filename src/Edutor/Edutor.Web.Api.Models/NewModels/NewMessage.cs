using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.NewModels
{
    public class NewMessage 
    {
        //public int ConversationId { get; set; }
        //public int MessageId { get; set; }
        public int ToId { get; set; }
        public int FromId { get; set; }
        public string Text { get; set; }
    }
}
