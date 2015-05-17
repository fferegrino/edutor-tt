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
    public class GetNotificationsQueryProcessor : IGetNotificationsQueryProcessor
    {
        private readonly IDateTime _dateTime;
        private readonly ISession _session;
        private readonly IUserSession _userSession;

        public GetNotificationsQueryProcessor(IDateTime dateTime, ISession session, IUserSession userSession)
        {
            _dateTime = dateTime;
            _userSession = userSession;
            _session = session;
        }


        public QueryResult<Notification> GetNotificationsForSchoolUser(int schoolUser, PagedDataRequest requestInfo)
        {
            var q = _session.QueryOver<Notification>().OrderBy(nn => nn.CreationDate).Asc.Where(not => not.SchoolUser.UserId == schoolUser);

            var totalItemCount = q.ToRowCountQuery().RowCount();

            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);

            var users = q.Skip(startIndex).Take(requestInfo.PageSize).List();

            var qResult = new QueryResult<Notification>(users, totalItemCount, requestInfo.PageSize);

            return qResult;
        }

        public QueryResult<Notification> GetNotificationsForStudent(int studentId, PagedDataRequest requestInfo)
        {

            var teachings = _session.QueryOver<NotificationDetail>().Where(t => t.Student.StudentId == studentId);

            var totalItemCount = teachings.ToRowCountQuery().RowCount();

            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);

            var selected = teachings.Skip(startIndex).Take(requestInfo.PageSize).List();

            var teachers = new List<Notification>();
            foreach (var t in selected)
                teachers.Add(_session.QueryOver<Notification>().Where(u => u.NotificationId == t.Notification.NotificationId).SingleOrDefault());

            var qResult = new QueryResult<Notification>(teachers, totalItemCount, requestInfo.PageSize);

            return qResult;
        }

        public Notification GetNotification(int notificationId)
        {
            return
                _session.QueryOver<Notification>().Where(n => n.NotificationId == notificationId).SingleOrDefault();
        }

    }
}
