using Edutor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.SqlServer.Mapping
{
    public class MessageMap : VersionedClassMap<Message>
    {
        public MessageMap()
        {
            Table("Messages");
            Id(x => x.MessageId);
            Map(x => x.Text).Not.Nullable();
            Map(x => x.SentDate).Not.Nullable();
            Map(x => x.SeenDate);
            References<User>(x => x.To).Column("ToId");
            References<User>(x => x.From).Column("FromId");
            References<Conversation>(c=> c.Conversation).Column("ConversationId");
        }
    }
}
