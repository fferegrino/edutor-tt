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
    public class AddEnrollmentQueryProcessor : IAddEnrollmentQueryProcessor
    {
        private readonly IDateTime _dateTime;
        private readonly ISession _session;
        private readonly IUserSession _userSession;

        public AddEnrollmentQueryProcessor(IDateTime dateTime, ISession session, IUserSession userSession)
        {
            _dateTime = dateTime;
            _userSession = userSession;
            _session = session;
        }
        public void AddEnrollment(Entities.Enrollment enrollment)
        {
            enrollment.Student = _session.QueryOver<Entities.Student>().Where(x => x.StudentId == enrollment.StudentId).List().FirstOrDefault();
            enrollment.Group = _session.QueryOver<Entities.Group>().Where(x => x.GroupId == enrollment.GroupId).List().FirstOrDefault();

            _session.SaveOrUpdate(enrollment);
        }
    }
}
