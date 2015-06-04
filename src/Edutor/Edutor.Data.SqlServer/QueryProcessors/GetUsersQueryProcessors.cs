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

        public QueryResult<User> GetSchoolUsersForGroup(int groupId, PagedDataRequest requestInfo)
        {
            var teachings = _session.QueryOver<Teaching>().Where(t => t.Group.GroupId == groupId);


            var totalItemCount = teachings.ToRowCountQuery().RowCount();

            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);

            var selected = teachings.Skip(startIndex).Take(requestInfo.PageSize).List();

            var teachers = new List<User>();
            foreach (var t in selected)
                teachers.Add(_session.QueryOver<User>().Where(u => u.UserId == t.SchoolUser.UserId).List().FirstOrDefault());

            var qResult = new QueryResult<User>(teachers, totalItemCount, requestInfo.PageSize);

            return qResult;
        }

        public User GetSchoolUser(int userId)
        {
            var q = _session.QueryOver<User>().Where(user => user.Type == User.SchoolUserType && user.UserId == userId).List().FirstOrDefault();
            if (q == null) throw new Edutor.Data.Exceptions.ObjectNotFoundException("No existe un usuario escolar con id " + userId);
            return q;
        }

        public User GetTutor(int userId)
        {
            var q = _session.QueryOver<User>().Where(user => user.Type == User.TutorType && user.UserId == userId).List().FirstOrDefault();
            if (q == null) throw new Edutor.Data.Exceptions.ObjectNotFoundException("No existe un tutor con id " + userId);
            return q;
        }

        public User GetSchoolUser(string curp)
        {
            var q = _session.QueryOver<User>().Where(user => user.Type == User.SchoolUserType && user.Curp == (curp)).List().FirstOrDefault();
            if (q == null) throw new Edutor.Data.Exceptions.ObjectNotFoundException("No existe un usuario escolar con CURP " + curp);
            return q;
        }

        public User GetTutor(string curp)
        {
            var q = _session.QueryOver<User>().Where(user => user.Type == User.TutorType && user.Curp == (curp)).List().FirstOrDefault();
            if (q == null) throw new Edutor.Data.Exceptions.ObjectNotFoundException("No existe un tutor con CURP " + curp);
            return q;
        }


        public QueryResult<TeacherForStudent> GetTeachersForStudent(int studentId, PagedDataRequest requestInfo)
        {

            var teachings = _session.QueryOver<TeacherForStudent>().Where(t => t.StudentId == studentId);

            //var groupsForStudent = _session.QueryOver<Group>().JoinQueryOver(e => e.Students).Where(f => f.Any(student => student.StudentId == studentId));
            //var teachersForGroup = groupsForStudent.Inner.JoinQueryOver()


            var totalItemCount = teachings.ToRowCountQuery().RowCount();

            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);

            var selected = teachings.Skip(startIndex).Take(requestInfo.PageSize).List();


            var qResult = new QueryResult<TeacherForStudent>(selected, totalItemCount, requestInfo.PageSize);

            return qResult;
        }



        public QueryResult<TutorForTeacher> GetTutorsForGroup(string groupName, PagedDataRequest requestInfo)
        {
            var teachings = _session.QueryOver<TutorForTeacher>().Where(t => t.GroupName == groupName);

            var totalItemCount = teachings.ToRowCountQuery().RowCount();

            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);

            var selected = teachings.Skip(startIndex).Take(requestInfo.PageSize).List();


            var qResult = new QueryResult<TutorForTeacher>(selected, totalItemCount, requestInfo.PageSize);

            return qResult;
        }


        public QueryResult<TutorForTeacher> GetTutorsForGroup(int groupId, PagedDataRequest requestInfo)
        {
            var teachings = _session.QueryOver<TutorForTeacher>().Where(t => t.GroupId == groupId);

            var totalItemCount = teachings.ToRowCountQuery().RowCount();

            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);

            var selected = teachings.Skip(startIndex).Take(requestInfo.PageSize).List();


            var qResult = new QueryResult<TutorForTeacher>(selected, totalItemCount, requestInfo.PageSize);

            return qResult;
        }

        public QueryResult<TutorForTeacher> GetTutorsForTeacher(int teacherId, PagedDataRequest requestInfo)
        {
            var teachings = _session.QueryOver<TutorForTeacher>().Where(t => t.TeacherId == teacherId);

            var totalItemCount = teachings.ToRowCountQuery().RowCount();

            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);

            var selected = teachings.Skip(startIndex).Take(requestInfo.PageSize).List();


            var qResult = new QueryResult<TutorForTeacher>(selected, totalItemCount, requestInfo.PageSize);

            return qResult;
        }
    }
}
