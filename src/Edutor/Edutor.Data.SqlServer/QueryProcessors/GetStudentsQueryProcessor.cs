using Edutor.Common;
using Edutor.Common.Security;
using Edutor.Data.Entities;
using Edutor.Common.Extensions;
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


        public QueryResult<Student> GetStudentsForTutor(int tutorId, PagedDataRequest requestInfo, bool onlyActive = true)
        {
            IQueryOver<Student> q = null;
            if (onlyActive)
            {
                q = _session.QueryOver<Student>().Where(s => s.Tutor.UserId == tutorId && s.IsActive == true);
            }
            else
            {
                q = _session.QueryOver<Student>().Where(s => s.Tutor.UserId == tutorId);
            }

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
                teachers.Add(_session.QueryOver<Student>().Where(u => u.StudentId == t.Student.StudentId).List().FirstOrDefault());

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
            //    teachers.Add(_session.QueryOver<Student>().Where(u => u.StudentId == t.Student.StudentId).List().FirstOrDefault());

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
            //    teachers.Add(_session.QueryOver<Student>().Where(u => u.StudentId == t.Student.StudentId).List().FirstOrDefault());

            var qResult = new QueryResult<Invitation>(selected, totalItemCount, requestInfo.PageSize);

            return qResult;
        }

        public QueryResult<Answer> GetStudentsForQuestion(int questionId, PagedDataRequest requestInfo)
        {
            var teachings = _session.QueryOver<Answer>().Where(t => t.Question.QuestionId == questionId);

            var totalItemCount = teachings.ToRowCountQuery().RowCount();

            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);

            var selected = teachings.Skip(startIndex).Take(requestInfo.PageSize).List();

            foreach (var ans in selected)
                ans.ActualAnswer = _session.QueryOver<PossibleAnswer>().Where(v => v.PossibleAnswerId == ans.ActualAnswerId && v.Question.QuestionId == ans.Question.QuestionId).List().FirstOrDefault();

            var qResult = new QueryResult<Answer>(selected, totalItemCount, requestInfo.PageSize);

            return qResult;
        }

        public Student GetStudent(int studentId)
        {

            var userId = _userSession.UserId;
            bool allowQuery = true;
            if (_userSession.IsInRole(Constants.RoleNames.Teacher))
            {
                allowQuery = _session.QueryOver<TeacherForStudent>().Where(te => te.StudentId == studentId && te.UserId == userId).List().Any();
                if (!allowQuery)
                {
                    throw new Data.Exceptions.UnAuthorizedException("Como profesor solamente puedes acceder a los alumnos de tus grupos");
                }
            }
            else if (_userSession.IsInRole(Constants.RoleNames.Tutor))
            {
                allowQuery = _session.QueryOver<Student>().Where(te => te.StudentId == studentId && te.TutorId == userId).List().Any();
                if (!allowQuery)
                {
                    throw new Data.Exceptions.UnAuthorizedException("Como tutor solamente puedes acceder a tus tutorados");
                }
            }


            var q = _session.QueryOver<Student>().Where(user => user.StudentId == studentId).List().FirstOrDefault();
            if (q == null) throw new Edutor.Data.Exceptions.ObjectNotFoundException("No existe un estudiante con Id " + studentId);
            return q;
        }


        public Student GetStudent(string curp)
        {
            var q = _session.QueryOver<Student>().Where(user => user.Curp == (curp)).List().FirstOrDefault();
            if (q == null) throw new Edutor.Data.Exceptions.ObjectNotFoundException("No existe un estudiante con CURP " + curp);
            return GetStudent(q.StudentId);
        }

        public Student GetStudentByToken(string token)
        {
            var q = _session.QueryOver<Student>().Where(user => user.Token == (token)).List().FirstOrDefault();
            return q;
        }

        public Invitation GetStudentsForEvent(int eventId, int studentId)
        {
            var q = _session.QueryOver<Invitation>().Where(t => t.Event.EventId == eventId
                && t.Student.StudentId == studentId).List().FirstOrDefault();
            return q;
        }

        public Answer GetStudentsForQuestion(int questionId, int studentId)
        {
            var ans = _session.QueryOver<Answer>().Where(t => t.Question.QuestionId == questionId
                && t.Student.StudentId == studentId).List().FirstOrDefault();

            ans.ActualAnswer = _session.QueryOver<PossibleAnswer>().Where(v => v.PossibleAnswerId == ans.ActualAnswerId && v.Question.QuestionId == ans.Question.QuestionId).List().FirstOrDefault();

            return ans;
        }

        public NotificationDetail GetStudentsForNotification(int notificationId, int studentId)
        {
            var q = _session.QueryOver<NotificationDetail>().Where(t => t.Notification.NotificationId == notificationId
                && t.Student.StudentId == studentId).List().FirstOrDefault();

            return q;
        }


        public IList<Student> GetAllStudentsBrute()
        {
            return _session.QueryOver<Student>().List();
        }
    }
}
