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
    public class GetSchoolUsersQueryProcesors : IGetSchoolUsersQueryProcessors
    {
        private readonly IDateTime _dateTime;
        private readonly ISession _session;
        private readonly IUserSession _userSession;

        public GetSchoolUsersQueryProcesors(IDateTime dateTime, ISession session, IUserSession userSession)
        {
            _dateTime = dateTime;
            _userSession = userSession;
            _session = session;
        }

        public SchoolUser GetById(int id)
        {
            return _session.QueryOver<SchoolUser>().Where(x => x.SchoolUserId == id).SingleOrDefault();
        }
    }
}
