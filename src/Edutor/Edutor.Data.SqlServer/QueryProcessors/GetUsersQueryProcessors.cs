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
    public class GetUsersQueryProcessor : IGetUsersQueryProcessor
    {
        private readonly IDateTime _dateTime;
        private readonly ISession _session;
        private readonly IUserSession _userSession;

        public GetUsersQueryProcessor(IDateTime dateTime, ISession session, IUserSession userSession)
        {
            _dateTime = dateTime;
            _userSession = userSession;
            _session = session;
        }


        public QueryResult<User> GetSchoolUsers(PagedDataRequest requestInfo)
        {
            var q = _session.QueryOver<User>().Where(user => user.Type == User.SchoolUserType);

            var totalItemCount = q.ToRowCountQuery().RowCount();

            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);

            var users = q.Skip(startIndex).Take(requestInfo.PageSize).List();

            var qResult = new QueryResult<User>(users, totalItemCount, requestInfo.PageSize);

            return qResult;
        }

        public QueryResult<User> GetTutors(PagedDataRequest requestInfo)
        {
            var q = _session.QueryOver<User>().Where(user => user.Type == User.TutorType);

            var totalItemCount = q.ToRowCountQuery().RowCount();

            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);

            var users = q.Skip(startIndex).Take(requestInfo.PageSize).List();

            var qResult = new QueryResult<User>(users, totalItemCount, requestInfo.PageSize);

            return qResult;
        }


        public User GetSchoolUser(int userId)
        {
            var q = _session.QueryOver<User>().Where(user => user.Type == User.SchoolUserType && user.UserId == userId).SingleOrDefault();
            return q;
        }

        public User GetTutor(int userId)
        {
            var q = _session.QueryOver<User>().Where(user => user.Type == User.SchoolUserType && user.UserId == userId).SingleOrDefault();
            return q;
        }
    }
}
