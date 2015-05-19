using Edutor.Common;
using Edutor.Common.Security;
using Edutor.Data.QueryProcessors;
using NHibernate;
using NHibernate.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.SqlServer.QueryProcessors
{
    public class AddUserQueryProcessor : IAddUserQueryProcessor
    {

        private readonly IDateTime _dateTime;
        private readonly ISession _session;
        private readonly IUserSession _userSession;

        public AddUserQueryProcessor(IDateTime dateTime, ISession session, IUserSession userSession)
        {
            _dateTime = dateTime;
            _userSession = userSession;
            _session = session;
        }

        public void AddUser(Entities.User user)
        {
            try
            {
                _session.SaveOrUpdate(user);
            }
            catch (GenericADOException ex)
            {
                throw new Edutor.Data.Exceptions.DuplicateEntityException("This is a duplicate user, check the unique fields within your entity (either Curp or Email)");
            }
        }
    }
}
