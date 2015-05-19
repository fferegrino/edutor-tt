using Edutor.Common;
using Edutor.Common.Security;
using Edutor.Data.Entities;
using Edutor.Data.QueryProcessors;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.SqlServer.QueryProcessors
{
    public class GetConversationsQueryProcessor : IGetConversationsQueryProcessor
    {
        private readonly IDateTime _dateTime;
        private readonly ISession _session;
        private readonly IUserSession _userSession;

        public GetConversationsQueryProcessor(IDateTime dateTime, ISession session, IUserSession userSession)
        {
            _dateTime = dateTime;
            _userSession = userSession;
            _session = session;
        }

        public Conversation GetConversation(int conversationId)
        {
            var q = _session.QueryOver<Conversation>().Where(c => c.ConversationId == conversationId).SingleOrDefault();
            return q;
        }

        public Message GetMessagesForConversation(int conversationId, int messageId)
        {
            var q = _session.QueryOver<Message>().Where(m => m.ConversationId == conversationId && m.MessageId == messageId).SingleOrDefault();
            return q;
        }

        public QueryResult<Message> GetMessagesForConversation(int conversationId, PagedDataRequest requestInfo)
        {

            var q = _session.QueryOver<Message>().OrderBy(nn => nn.SentDate).Desc.Where(message => message.Conversation.ConversationId == conversationId);

            var totalItemCount = q.ToRowCountQuery().RowCount();

            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);

            var users = q.Skip(startIndex).Take(requestInfo.PageSize).List();

            var qResult = new QueryResult<Message>(users, totalItemCount, requestInfo.PageSize);

            return qResult;
        }
    }
}
