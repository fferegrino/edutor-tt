using Edutor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.QueryProcessors
{
    public interface IGetConversationsQueryProcessor
    {
        QueryResult<Message> GetMessagesForConversation(int conversationId,PagedDataRequest requestInfo);
        Message GetMessagesForConversation(int conversationId, int messageId);

        IList<Message> GetLastMessagesForConversation(int conversationId, int messageCount);

        Conversation GetConversation(int conversationId);
        
    }
}
