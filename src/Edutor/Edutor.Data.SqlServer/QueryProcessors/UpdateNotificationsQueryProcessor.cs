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
    public class UpdateNotificationsQueryProcessor : IUpdateNotificationsQueryProcessor
    {
        private readonly IDateTime _dateTime;
        private readonly ISession _session;
        private readonly IUserSession _userSession;

        public UpdateNotificationsQueryProcessor(IDateTime dateTime, ISession session, IUserSession userSession)
        {
            _dateTime = dateTime;
            _userSession = userSession;
            _session = session;
        }

        public void MarkAsSeen(NotificationDetail notificationDetail)
        {
            notificationDetail.Student = _session.QueryOver<Student>().Where(s => s.StudentId == notificationDetail.StudentId).List().FirstOrDefault();
            notificationDetail.Notification = _session.QueryOver<Notification>().Where(s => s.NotificationId == notificationDetail.NotificationId).List().FirstOrDefault();
            notificationDetail.Seen = true;
            _session.Update(notificationDetail);
        }
    }
}
