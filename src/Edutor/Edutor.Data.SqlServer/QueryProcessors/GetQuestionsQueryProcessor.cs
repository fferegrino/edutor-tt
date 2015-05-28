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
    public class GetQuestionsQueryProcessor : IGetQuestionsQueryProcessor
    {
        private readonly IDateTime _dateTime;
        private readonly ISession _session;
        private readonly IUserSession _userSession;

        public GetQuestionsQueryProcessor(IDateTime dateTime, ISession session, IUserSession userSession)
        {
            _dateTime = dateTime;
            _userSession = userSession;
            _session = session;
        }


        public QueryResult<Question> GetQuestionsForSchoolUser(int schoolUser, PagedDataRequest requestInfo)
        {
            var q = _session.QueryOver<Question>().OrderBy(nn => nn.CreationDate).Desc.Where(not => not.SchoolUser.UserId == schoolUser);

            var totalItemCount = q.ToRowCountQuery().RowCount();

            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);

            var users = q.Skip(startIndex).Take(requestInfo.PageSize).List();

            var qResult = new QueryResult<Question>(users, totalItemCount, requestInfo.PageSize);

            return qResult;
        }

        public QueryResult<Question> GetQuestionsForStudent(int studentId, PagedDataRequest requestInfo)
        {

            var teachings = _session.QueryOver<Answer>().Where(t => t.Student.StudentId == studentId).JoinQueryOver(x => x.Question).OrderBy(q => q.CreationDate).Desc;

            var totalItemCount = teachings.ToRowCountQuery().RowCount();

            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);

            var selected = teachings.Skip(startIndex).Take(requestInfo.PageSize).List();

            var teachers = new List<Question>();
            foreach (var t in selected)
                teachers.Add(_session.QueryOver<Question>().Where(u => u.QuestionId == t.Question.QuestionId).SingleOrDefault());

            var qResult = new QueryResult<Question>(teachers, totalItemCount, requestInfo.PageSize);

            return qResult;
        }

        public Question GetQuestion(int questionId)
        {
            return
                _session.QueryOver<Question>().Where(n => n.QuestionId == questionId).SingleOrDefault();
        }
    }
}
