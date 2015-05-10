using Edutor.Common;
using Edutor.Common.Security;
using Edutor.Data.QueryProcessors;
using NHibernate;

namespace Edutor.Data.SqlServer.QueryProcessors
{
    public class AddStudentQueryProcessor : IAddStudentQueryProcessor
    {

        private readonly IDateTime _dateTime;
        private readonly ISession _session;
        private readonly IUserSession _userSession;

        public AddStudentQueryProcessor(IDateTime dateTime, ISession session, IUserSession userSession)
        {
            _dateTime = dateTime;
            _userSession = userSession;
            _session = session;
        }

        public void AddStudent(Entities.Student student)
        {
            // TODO: Implementar servicio de tokens
            student.Token = "AABABABA";
            var tutors = _session.QueryOver<Entities.User>()

                .Where(x => x.UserId == student.TutorId).SingleOrDefault();

            student.Tutor = tutors;
            _session.SaveOrUpdate(student);
        }
    }
}
