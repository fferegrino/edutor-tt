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
    public class AddEventQueryProcessor : IAddEventQueryProcessor
    {
        private readonly IDateTime _dateTime;
        private readonly ISession _session;
        private readonly IUserSession _userSession;

        public AddEventQueryProcessor(IDateTime dateTime, ISession session, IUserSession userSession)
        {
            _dateTime = dateTime;
            _userSession = userSession;
            _session = session;
        }
        public void AddEvent(Entities.Event ev)
        {
            ev.SchoolUser = _session.QueryOver<Entities.User>().Where(x => x.UserId == ev.SchoolUserId).SingleOrDefault();
            ev.CreationDate = _dateTime.UtcNow;

            var group = _session.QueryOver<Entities.Group>().Where(g => g.GroupId == ev.GroupId).SingleOrDefault();
            ev.Group = group;

            //ev.Invitations = invitations.ToList();

            _session.Save(ev);
        }
    }
}
