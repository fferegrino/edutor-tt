using Edutor.Common;
using Edutor.Common.Security;
using Edutor.Data.QueryProcessors;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.SqlServer.QueryProcessors
{
    public class AddNotificationDetailQueryProcessor : IAddNotificationDetailQueryProcessor
    {
        private readonly IDateTime _dateTime;
        private readonly ISession _session;
        private readonly IUserSession _userSession;

        public AddNotificationDetailQueryProcessor(IDateTime dateTime, ISession session, IUserSession userSession)
        {
            _dateTime = dateTime;
            _userSession = userSession;
            _session = session;
        }

        public void AddInvitation(Entities.Invitation invitation)
        {

            var ev = _session.QueryOver<Entities.Event>().Where(g => g.EventId == invitation.EventId).SingleOrDefault();
            var student = _session.QueryOver<Entities.Student>().Where(g => g.StudentId == invitation.StudentId).SingleOrDefault();
            invitation.Student = student;
            invitation.Event = ev;

            _session.Save(invitation);

        }

        public void AddInvitations(IList<Entities.Invitation> invitations)
        {
            var x = invitations[0];
            var ev = _session.QueryOver<Entities.Event>().Where(g => g.EventId == x.EventId).SingleOrDefault();

            foreach (var invitation in invitations)
            {
                var student = _session.QueryOver<Entities.Student>().Where(g => g.StudentId == invitation.StudentId).SingleOrDefault();
                invitation.Student = student;
                invitation.Event = ev;
                _session.Save(invitation);
            }
        }


        public void AddNotificationDetail(Entities.NotificationDetail notificationDetail)
        {
            var notification = _session.QueryOver<Entities.Notification>().Where(g => g.NotificationId == notificationDetail.NotificationId).SingleOrDefault();
            var student = _session.QueryOver<Entities.Student>().Where(g => g.StudentId == notificationDetail.StudentId).SingleOrDefault();
            notificationDetail.Student = student;
            notificationDetail.Notification = notification;

            _session.Save(notificationDetail);
        }

        public void AddNotificationDetails(IList<Entities.NotificationDetail> notificationDetails)
        {
            var x = notificationDetails[0];
            var notification = _session.QueryOver<Entities.Notification>().Where(g => g.NotificationId == x.NotificationId).SingleOrDefault();

            foreach (var notificationDetail in notificationDetails)
            {
                var student = _session.QueryOver<Entities.Student>().Where(g => g.StudentId == notificationDetail.StudentId).SingleOrDefault();
                notificationDetail.Student = student;
                notificationDetail.Notification = notification;
                _session.Save(notificationDetail);
            }
        }
    }
}
