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

        public QueryResult<NotificationDetail> GetStudentsForNotification(int notificationId, PagedDataRequest requestInfo)
        {
            var teachings = _session.QueryOver<NotificationDetail>().Where(t => t.Notification.NotificationId == notificationId);

            var totalItemCount = teachings.ToRowCountQuery().RowCount();

            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);

            var selected = teachings.Skip(startIndex).Take(requestInfo.PageSize).List();

            //var teachers = new List<Student>();
            //foreach (var t in selected)
            //    teachers.Add(_session.QueryOver<Student>().Where(u => u.StudentId == t.Student.StudentId).SingleOrDefault());

            var qResult = new QueryResult<NotificationDetail>(selected, totalItemCount, requestInfo.PageSize);

            return qResult;
        }

        public QueryResult<Invitation> GetStudentsForEvent(int eventId, PagedDataRequest requestInfo)
        {
            var teachings = _session.QueryOver<Invitation>().Where(t => t.Event.EventId == eventId);

            var totalItemCount = teachings.ToRowCountQuery().RowCount();

            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);

            var selected = teachings.Skip(startIndex).Take(requestInfo.PageSize).List();

            //var teachers = new List<Student>();
            //foreach (var t in selected)
            //    teachers.Add(_session.QueryOver<Student>().Where(u => u.StudentId == t.Student.StudentId).SingleOrDefault());

            var qResult = new QueryResult<Invitation>(selected, totalItemCount, requestInfo.PageSize);

            return qResult;
        }

        public QueryResult<Answer> GetStudentsForQuestion(int questionId, PagedDataRequest requestInfo)
        {
            var teachings = _session.QueryOver<Answer>().Where(t => t.Question.QuestionId == questionId);

            var totalItemCount = teachings.ToRowCountQuery().RowCount();

            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);

            var selected = teachings.Skip(startIndex).Take(requestInfo.PageSize).List();

            //var teachers = new List<Student>();
            //foreach (var t in selected)
            //    teachers.Add(_session.QueryOver<Student>().Where(u => u.StudentId == t.Student.StudentId).SingleOrDefault());

            var qResult = new QueryResult<Answer>(selected, totalItemCount, requestInfo.PageSize);

            return qResult;
        }

        public Student GetStudent(int studentId)
        {
            var q = _session.QueryOver<Student>().Where(user => user.StudentId == studentId).SingleOrDefault();
            return q;
        }


        public Student GetStudent(string curp)
        {
            var q = _session.QueryOver<Student>().Where(user => user.Curp == (curp)).SingleOrDefault();
            return q;
        }

        public Student GetStudentByToken(string token)
        {
            var q = _session.QueryOver<Student>().Where(user => user.Token == (token)).SingleOrDefault();
            return q;
        }

        public Invitation GetStudentsForEvent(int eventId, int studentId)
        {
            return _session.QueryOver<Invitation>().Where(t => t.Event.EventId == eventId
                && t.Student.StudentId == studentId).SingleOrDefault();
        }

        public Answer GetStudentsForQuestion(int questionId, int studentId)
        {
            return _session.QueryOver<Answer>().Where(t => t.Question.QuestionId == questionId
                && t.Student.StudentId == studentId).SingleOrDefault();
        }

        public NotificationDetail GetStudentsForNotification(int notificationId, int studentId)
        {
            return _session.QueryOver<NotificationDetail>().Where(t => t.Notification.NotificationId == notificationId
                && t.Student.StudentId == studentId).SingleOrDefault();
        }
    }
}
