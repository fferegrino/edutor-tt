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
    public class UpdateEventsQueryProcessor : IUpdateEventsQueryProcessor
    {
        private readonly IDateTime _dateTime;
        private readonly ISession _session;
        private readonly IUserSession _userSession;

        public UpdateEventsQueryProcessor(IDateTime dateTime, ISession session, IUserSession userSession)
        {
            _dateTime = dateTime;
            _userSession = userSession;
            _session = session;
        }

        public void Rsvp(Invitation invitation)
        {
            invitation.Student = _session.QueryOver<Student>().Where(s => s.StudentId == invitation.StudentId).List().FirstOrDefault();
            invitation.Event = _session.QueryOver<Event>().Where(s => s.EventId == invitation.EventId).List().FirstOrDefault();
            _session.Update(invitation);
        }



    }
}
