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
    public class GetStudentsQueryProcessor : IGetStudentsQueryProcessor
    {
        private readonly IDateTime _dateTime;
        private readonly ISession _session;
        private readonly IUserSession _userSession;

        public GetStudentsQueryProcessor(IDateTime dateTime, ISession session, IUserSession userSession)
        {
            _dateTime = dateTime;
            _userSession = userSession;
            _session = session;
        }

        public QueryResult<Student> GetStudentsForTutor(int tutorId, PagedDataRequest requestInfo)
        {
            var q = _session.QueryOver<Student>().Where(s => s.Tutor.UserId == tutorId);

            var totalItemCount = q.ToRowCountQuery().RowCount();

            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);

            var users = q.Skip(startIndex).Take(requestInfo.PageSize).List();

            var qResult = new QueryResult<Student>(users, totalItemCount, requestInfo.PageSize);

            return qResult;

        }

        public QueryResult<Student> GetStudents(PagedDataRequest requestInfo)
        {
            var q = _session.QueryOver<Student>();

            var totalItemCount = q.ToRowCountQuery().RowCount();

            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);

            var users = q.Skip(startIndex).Take(requestInfo.PageSize).List();

            var qResult = new QueryResult<Student>(users, totalItemCount, requestInfo.PageSize);

            return qResult;
        }


        public QueryResult<Student> GetStudentsForGroup(int groupId, PagedDataRequest requestInfo)
        {
            var teachings = _session.QueryOver<Enrollment>().Where(t => t.Group.GroupId == groupId);

            var totalItemCount = teachings.ToRowCountQuery().RowCount();

            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);

            var selected = teachings.Skip(startIndex).Take(requestInfo.PageSize).List();

            var teachers = new List<Student>();
            foreach (var t in selected)
                teachers.Add(_session.QueryOver<Student>().Where(u => u.StudentId == t.Student.StudentId).SingleOrDefault());

            var qResult = new QueryResult<Student>(teachers, totalItemCount, requestInfo.PageSize);

            return qResult;
        }

        public Student GetStudent(int studentId)
        {
            var q = _session.QueryOver<Student>().Where(user => user.StudentId == studentId).SingleOrDefault();
            return q;
        }

        public Student GetStudent(string token)
        {
            var q = _session.QueryOver<Student>().Where(user => user.Token.Equals(token)).SingleOrDefault();
            return q;
        }

    }
}
