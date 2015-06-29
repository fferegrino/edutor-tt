using Edutor.Common;
using Edutor.Common.Security;
using Edutor.Data.Entities;
using Edutor.Data.Exceptions;
using Edutor.Data.QueryProcessors;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.SqlServer.QueryProcessors
{
    public class DeleteInteractionsQueryProcessor : IDeleteInteractionsQueryProcessor
    {
        private readonly IDateTime _dateTime;
        private readonly ISession _session;
        private readonly IUserSession _userSession;

        public DeleteInteractionsQueryProcessor(IDateTime dateTime, ISession session, IUserSession userSession)
        {
            _dateTime = dateTime;
            _userSession = userSession;
            _session = session;
        }


        public void DeleteQuestion(int questionId)
        {
            var isAdmin = _userSession.IsInRole(Constants.RoleNames.Administrator);
            var stuffToErase = _session.QueryOver<Question>().Where(q => q.QuestionId == questionId).Take(1).SingleOrDefault();
            if (stuffToErase != null)
                if (isAdmin || stuffToErase.SchoolUser.UserId == _userSession.UserId)
                {
                    _session.Delete(stuffToErase);
                }
                else
                {
                    throw new Edutor.Data.Exceptions.UnAuthorizedException("Como profesor solamente puedes eliminar preguntas que tu creaste");
                }
        }

        public void DeleteEvent(int eventId)
        {
            var isAdmin = _userSession.IsInRole(Constants.RoleNames.Administrator);
            var stuffToErase = _session.QueryOver<Event>().Where(q => q.EventId == eventId).Take(1).SingleOrDefault();
            if (stuffToErase != null)
                if (isAdmin || stuffToErase.SchoolUser.UserId == _userSession.UserId)
                {
                    _session.Delete(stuffToErase);
                }
                else
                {
                    throw new Edutor.Data.Exceptions.UnAuthorizedException("Como profesor solamente puedes eliminar eventos que tu creaste");
                }
        }

        public void DeleteNotification(int notificationId)
        {
            var isAdmin = _userSession.IsInRole(Constants.RoleNames.Administrator);
            var stuffToErase = _session.QueryOver<Notification>().Where(q => q.NotificationId == notificationId).Take(1).SingleOrDefault();
            if (stuffToErase != null)
                if (isAdmin || stuffToErase.SchoolUser.UserId == _userSession.UserId)
                {
                    _session.Delete(stuffToErase);
                }
                else
                {
                    throw new Edutor.Data.Exceptions.UnAuthorizedException("Como profesor solamente puedes eliminar notificaciones que tu creaste");
                }
        }


        public void DeleteConversation(int conversationId)
        {
            var conversationToErase = _session.QueryOver<Conversation>().Where(c => c.ConversationId == conversationId).Take(1).SingleOrDefault();
            _session.Delete(conversationToErase);
        }
    }
}
