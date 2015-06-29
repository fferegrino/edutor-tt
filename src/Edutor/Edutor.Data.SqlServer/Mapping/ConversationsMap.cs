using Edutor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.SqlServer.Mapping
{
    public class ConversationsMap : VersionedClassMap<Conversation>
    {
        public ConversationsMap()
        {
            Table("Conversations");
            Id(x => x.ConversationId);
            References<User>(x => x.User1).Column("User1Id");
            References<User>(x => x.User2).Column("User2Id");
            HasMany<Message>(c=> c.Messages).KeyColumn("ConversationId").Cascade.AllDeleteOrphan().Inverse();
        }
    }
}
