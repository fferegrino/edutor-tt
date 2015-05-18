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
    public class GetEventsQueryProcessor : IGetEventsQueryProcessor
    {
        private readonly IDateTime _dateTime;
        private readonly ISession _session;
        private readonly IUserSession _userSession;

        public GetEventsQueryProcessor(IDateTime dateTime, ISession session, IUserSession userSession)
        {
            _dateTime = dateTime;
            _userSession = userSession;
            _session = session;
        }


        public QueryResult<Event> GetEventsForSchoolUser(int schoolUser, PagedDataRequest requestInfo)
        {
            var q = _session.QueryOver<Event>().OrderBy(nn => nn.CreationDate).Asc.Where(not => not.SchoolUser.UserId == schoolUser);

            var totalItemCount = q.ToRowCountQuery().RowCount();

            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);

            var users = q.Skip(startIndex).Take(requestInfo.PageSize).List();

            var qResult = new QueryResult<Event>(users, totalItemCount, requestInfo.PageSize);

            return qResult;
        }

        public QueryResult<Event> GetEventsForStudent(int studentId, PagedDataRequest requestInfo)
        {

            var teachings = _session.QueryOver<Invitation>().Where(t => t.Student.StudentId == studentId);

            var totalItemCount = teachings.ToRowCountQuery().RowCount();

            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);

            var selected = teachings.Skip(startIndex).Take(requestInfo.PageSize).List();

            var teachers = new List<Event>();
            foreach (var t in selected)
                teachers.Add(_session.QueryOver<Event>().Where(u => u.EventId == t.Event.EventId).SingleOrDefault());

            var qResult = new QueryResult<Event>(teachers, totalItemCount, requestInfo.PageSize);

            return qResult;
        }

        public Event GetEvent(int eventId)
        {
            return
                _session.QueryOver<Event>().Where(n => n.EventId == eventId).SingleOrDefault();
        }
    }
}
