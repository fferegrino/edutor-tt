using Edutor.Common;
using Edutor.Common.Security;
using Edutor.Data.QueryProcessors;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.SqlServer.QueryProcessors
{
    public class AddPossibleAnswerQueryProcessor : IAddPossibleAnswerQueryProcessor
    {
        private readonly IDateTime _dateTime;
        private readonly ISession _session;
        private readonly IUserSession _userSession;

        public AddPossibleAnswerQueryProcessor(IDateTime dateTime, ISession session, IUserSession userSession)
        {
            _dateTime = dateTime;
            _userSession = userSession;
            _session = session;
        }

        public void AddPossibleAnswer(Entities.PossibleAnswer p)
        {
            throw new NotImplementedException();
            //var ev = _session.QueryOver<Entities.Event>().Where(g => g.EventId == invitation.EventId).List().FirstOrDefault();
            //var student = _session.QueryOver<Entities.Student>().Where(g => g.StudentId == invitation.StudentId).List().FirstOrDefault();
            //invitation.Student = student;
            //invitation.Event = ev;

            //_session.Save(invitation);
        }

        public void AddPossibleAnswers(IList<Entities.PossibleAnswer> ps)
        {
            var x = ps[0];
            var qestuion = _session.QueryOver<Entities.Question>().Where(g => g.QuestionId == x.QuestionId).List().FirstOrDefault();

            foreach (var p in ps)
            {
                p.Question = qestuion;
                _session.Save(p);
            };
        }
    }
}
