﻿using Edutor.Common;
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
    public class AddQuestionQueryProcessor : IAddQuestionQueryProcessor
    {
        private readonly IDateTime _dateTime;
        private readonly ISession _session;
        private readonly IUserSession _userSession;

        public AddQuestionQueryProcessor(IDateTime dateTime, ISession session, IUserSession userSession)
        {
            _dateTime = dateTime;
            _userSession = userSession;
            _session = session;
        }

        public void AddInvitation(Entities.Invitation invitation)
        {

            var ev = _session.QueryOver<Entities.Event>().Where(g => g.EventId == invitation.EventId).List().FirstOrDefault();
            var student = _session.QueryOver<Entities.Student>().Where(g => g.StudentId == invitation.StudentId).List().FirstOrDefault();
            invitation.Student = student;
            invitation.Event = ev;

            _session.Save(invitation);

        }

        public void AddQuestion(Entities.Question q)
        {
            q.SchoolUser = _session.QueryOver<Entities.User>().Where(u => u.UserId == q.SchoolUserId).List().FirstOrDefault();
            q.Group = _session.QueryOver<Entities.Group>().Where(u => u.GroupId == q.GroupId).List().FirstOrDefault();
            q.CreationDate = _dateTime.UtcNow;
            _session.Save(q);
        }
    }
}
