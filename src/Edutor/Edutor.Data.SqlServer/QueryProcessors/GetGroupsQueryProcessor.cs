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
    public class GetGroupsQueryProcessor : IGetGroupsQueryProcessor
    {
        private readonly IDateTime _dateTime;
        private readonly ISession _session;
        private readonly IUserSession _userSession;

        public GetGroupsQueryProcessor(IDateTime dateTime, ISession session, IUserSession userSession)
        {
            _dateTime = dateTime;
            _userSession = userSession;
            _session = session;
        }


        public QueryResult<Group> GetGroups(PagedDataRequest requestInfo)
        {
            var q = _session.QueryOver<Group>();

            var totalItemCount = q.ToRowCountQuery().RowCount();

            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);

            var users = q.Skip(startIndex).Take(requestInfo.PageSize).List();

            var qResult = new QueryResult<Group>(users, totalItemCount, requestInfo.PageSize);

            return qResult;
        }

        public QueryResult<Group> GetGroupsForSchoolUser(int schoolUserId, PagedDataRequest requestInfo)
        {
            var teachings = _session.QueryOver<Teaching>().Where(t => t.SchoolUser.UserId == schoolUserId);


            var totalItemCount = teachings.ToRowCountQuery().RowCount();

            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);

            var selected = teachings.Skip(startIndex).Take(requestInfo.PageSize).List();

            var teachers = new List<Group>();
            foreach (var t in selected)
                teachers.Add(_session.QueryOver<Group>().Where(u => u.GroupId == t.Group.GroupId).SingleOrDefault());

            var qResult = new QueryResult<Group>(teachers, totalItemCount, requestInfo.PageSize);

            return qResult;
        }

        public Group GetGroup(int groupId)
        {
            var q = _session.QueryOver<Group>().Where(user => user.GroupId == groupId).SingleOrDefault();

            if (q == null) throw new Edutor.Data.Exceptions.ObjectNotFoundException("No existe un grupo con el Id " + groupId);

            return q;
        }



        public Group GetGroup(string name)
        {
            var q = _session.QueryOver<Group>().Where(user => user.Name == name).SingleOrDefault();

            if (q == null) throw new Edutor.Data.Exceptions.ObjectNotFoundException("No existe un grupo con el nombre " + name);

            return q;
        }
    }
}
