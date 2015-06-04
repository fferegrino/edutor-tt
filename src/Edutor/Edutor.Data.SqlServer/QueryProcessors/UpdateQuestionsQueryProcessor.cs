
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
    public class UpdateQuestionsQueryProcessor : IUpdateQuestionsQueryProcessor
    {
        private readonly IDateTime _dateTime;
        private readonly ISession _session;
        private readonly IUserSession _userSession;

        public UpdateQuestionsQueryProcessor(IDateTime dateTime, ISession session, IUserSession userSession)
        {
            _dateTime = dateTime;
            _userSession = userSession;
            _session = session;
        }

        public void AnswerQuestion(Answer answer)
        {
            answer.Student = _session.QueryOver<Student>().Where(s => s.StudentId == answer.StudentId).List().FirstOrDefault();
            answer.Question = _session.QueryOver<Question>().Where(s => s.QuestionId == answer.QuestionId).List().FirstOrDefault();
            answer.ActualAnswer = _session.QueryOver<PossibleAnswer>().Where(s => s.Question.QuestionId == answer.QuestionId && s.PossibleAnswerId == answer.ActualAnswerId).List().FirstOrDefault();
            answer.AnswerDate = _dateTime.UtcNow;
            _session.Update(answer);
        }
    }
}
