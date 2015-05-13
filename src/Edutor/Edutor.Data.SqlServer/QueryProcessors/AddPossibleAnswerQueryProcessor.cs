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

            //var ev = _session.QueryOver<Entities.Event>().Where(g => g.EventId == invitation.EventId).SingleOrDefault();
            //var student = _session.QueryOver<Entities.Student>().Where(g => g.StudentId == invitation.StudentId).SingleOrDefault();
            //invitation.Student = student;
            //invitation.Event = ev;

            //_session.Save(invitation);
        }

        public void AddPossibleAnswers(IList<Entities.PossibleAnswer> ps)
        {
            //var x = invitations[0];
            //var ev = _session.QueryOver<Entities.Event>().Where(g => g.EventId == x.EventId).SingleOrDefault();

            //foreach (var invitation in invitations)
            //{
            //    var student = _session.QueryOver<Entities.Student>().Where(g => g.StudentId == invitation.StudentId).SingleOrDefault();
            //    invitation.Student = student;
            //    invitation.Event = ev;
            //    _session.Save(invitation);
            //};
        }
    }
}
