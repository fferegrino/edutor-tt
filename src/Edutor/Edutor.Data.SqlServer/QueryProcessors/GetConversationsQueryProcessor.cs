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
            var q = _session.QueryOver<Conversation>().Where(c => c.ConversationId == conversationId).List().FirstOrDefault();
            if (q == null) throw new Edutor.Data.Exceptions.ObjectNotFoundException("La conversación con Id " + conversationId + " no existe.");
            return q;
        }

        public Message GetMessagesForConversation(int conversationId, int messageId)
        {
            var q = _session.QueryOver<Message>().Where(m => m.Conversation.ConversationId == conversationId && m.MessageId == messageId).List().FirstOrDefault();
            return q;
        }

        public IList<Message> GetLastMessagesForConversation(int conversationId, int messageCount)
        {
            var q = _session.QueryOver<Message>().OrderBy(nn => nn.SentDate).Desc.Where(message => message.Conversation.ConversationId == conversationId);
            var users = q.Take(messageCount).List();
            return users;
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


        public QueryResult<Conversation> GetConversationForUser(int userId, PagedDataRequest requestInfo)
        {
            var q = _session.QueryOver<Conversation>().Where(c => c.User1.UserId == userId || c.User2.UserId == userId);

            var totalItemCount = q.ToRowCountQuery().RowCount();

            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);

            var users = q.Skip(startIndex).Take(requestInfo.PageSize).List();


            var qResult = new QueryResult<Conversation>(users, totalItemCount, requestInfo.PageSize);
            return qResult;
        }
    }
}
