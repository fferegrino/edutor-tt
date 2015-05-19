using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.Entities
{
    public class Conversation : IVersionedEntity
    {
        public virtual int ConversationId { get; set; }

        public virtual int User1Id { get; set; }

        public virtual int User2Id { get; set; }

        public virtual User User1 { get; set; }

        public virtual User User2 { get; set; }

        public virtual IList<Message> Messages { get; set; }

        public virtual byte[] Version { get; set; }
    }
}
