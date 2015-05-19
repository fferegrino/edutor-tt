using Edutor.Common;
using Edutor.Common.Security;
using Edutor.Data.QueryProcessors;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edutor.Data.Entities;

namespace Edutor.Data.SqlServer.QueryProcessors
{
    public class AddConversationQueryProcessor : IAddConversationQueryProcessor
    {
        private readonly IDateTime _dateTime;
        private readonly ISession _session;
        private readonly IUserSession _userSession;

        public AddConversationQueryProcessor(IDateTime dateTime, ISession session, IUserSession userSession)
        {
            _dateTime = dateTime;
            _userSession = userSession;
            _session = session;
        }

        public void AddNewMessage(Message msg)
        {
            int fromId = msg.FromId;
            int toId = msg.ToId;

            var conversation = _session.QueryOver<Conversation>().Where(
                c => (c.User1.UserId == fromId && c.User2.UserId == toId)
                || (c.User1.UserId == toId && c.User2.UserId == fromId)).SingleOrDefault();

            var fromUser = _session.QueryOver<User>().Where(u => u.UserId == fromId).SingleOrDefault();
            var toUser = _session.QueryOver<User>().Where(u => u.UserId == toId).SingleOrDefault();

            if (conversation == null)
            {
                conversation = new Entities.Conversation
                {
                    User1 = fromUser,
                    User2 = toUser,
                };
                _session.Save(conversation);
            }

            msg.To = toUser;
            msg.From = fromUser;
            msg.Conversation = conversation;
            msg.SentDate = _dateTime.UtcNow;
            _session.Save(msg);
        }
    }
}
