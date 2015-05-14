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
    public class AddNotificationQueryProcessor : IAddNotificationQueryProcessor
    {
        private readonly IDateTime _dateTime;
        private readonly ISession _session;
        private readonly IUserSession _userSession;

        public AddNotificationQueryProcessor(IDateTime dateTime, ISession session, IUserSession userSession)
        {
            _dateTime = dateTime;
            _userSession = userSession;
            _session = session;
        }

        public void AddNotification(Entities.Notification notification)
        {
            notification.SchoolUser = _session.QueryOver<Entities.User>().Where(x => x.UserId == notification.SchoolUserId).SingleOrDefault();
            notification.Group = _session.QueryOver<Entities.Group>().Where(g => g.GroupId == notification.GroupId).SingleOrDefault();
            _session.Save(notification);
        }
    }
}
