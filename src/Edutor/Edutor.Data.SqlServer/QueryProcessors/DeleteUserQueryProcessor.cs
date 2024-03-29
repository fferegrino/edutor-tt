﻿using Edutor.Common;
using Edutor.Common.Security;
using Edutor.Data.Entities;
using Edutor.Data.Exceptions;
using Edutor.Data.QueryProcessors;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.SqlServer.QueryProcessors
{
    public class DeleteUserQueryProcessor : IDeleteUserQueryProcessor
    {
        private readonly IDateTime _dateTime;
        private readonly ISession _session;
        private readonly IUserSession _userSession;

        public DeleteUserQueryProcessor(IDateTime dateTime, ISession session, IUserSession userSession)
        {
            _dateTime = dateTime;
            _userSession = userSession;
            _session = session;
        }

        public void Delete(int userId)
        {
            int deletingUser = _userSession.UserId;
            var userToDelete = _session.QueryOver<User>().Where(user => user.UserId == userId).List().FirstOrDefault();
            if (userToDelete != null) // Allow idempotency
                _session.Delete(userToDelete);

        }
    }
}
