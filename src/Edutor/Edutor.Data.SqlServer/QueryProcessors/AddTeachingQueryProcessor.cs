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
    public class AddTeachingQueryProcessor : IAddTeachingQueryProcessor
    {
        private readonly IDateTime _dateTime;
        private readonly ISession _session;
        private readonly IUserSession _userSession;

        public AddTeachingQueryProcessor(IDateTime dateTime, ISession session, IUserSession userSession)
        {
            _dateTime = dateTime;
            _userSession = userSession;
            _session = session;
        }


        public void AddEnrollment(Entities.Teaching teaching)
        {
            teaching.SchoolUser = _session.QueryOver<Entities.User>().Where(x => x.UserId  == teaching.SchoolUserId).List().FirstOrDefault();
            teaching.Group = _session.QueryOver<Entities.Group>().Where(x => x.GroupId == teaching.GroupId).List().FirstOrDefault();
            _session.SaveOrUpdate(teaching);
        }
    }
}
