using Edutor.Data.QueryProcessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edutor.Data.Entities;
using Edutor.Common;
using NHibernate;
using Edutor.Common.Security;

namespace Edutor.Data.SqlServer.QueryProcessors
{
    public class AddGroupQueryProcessor : IAddGroupQueryProcessor
    {

        private readonly IDateTime _dateTime;
        private readonly ISession _session;
        private readonly IUserSession _userSession;

        public AddGroupQueryProcessor(IDateTime dateTime, ISession session, IUserSession userSession)
        {
            _dateTime = dateTime;
            _userSession = userSession;
            _session = session;
        }

        public void AddGroup(Group group)
        {
            _session.SaveOrUpdate(group);
        }
    }
}
