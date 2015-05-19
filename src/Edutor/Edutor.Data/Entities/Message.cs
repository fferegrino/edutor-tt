using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.Entities
{
    public class Message : IVersionedEntity
    {
        public virtual int MessageId { get; set; }
        public virtual int ConversationId { get; set; }
        public virtual int FromId { get; set; }
        public virtual int ToId { get; set; }
        public virtual DateTime SentDate { get; set; }
        public virtual DateTime? SeenDate { get; set; }
        public virtual string Text { get; set; }

        public virtual User From { get; set; }
        public virtual User To { get; set; }
        public virtual Conversation Conversation { get; set; }

        public virtual byte[] Version { get; set; }
    }
}
