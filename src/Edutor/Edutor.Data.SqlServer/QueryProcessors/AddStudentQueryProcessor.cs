using Edutor.Common;
using Edutor.Common.Security;
using Edutor.Data.QueryProcessors;
using NHibernate;
using System;

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
            var guid = Guid.NewGuid();
            string tkn = "E" + guid.ToString().Replace("-", String.Empty).Substring(0, 9);

            student.Token = tkn;

            var tutors = _session.QueryOver<Entities.User>()

                .Where(x => x.UserId == student.TutorId).SingleOrDefault();

            student.Tutor = tutors;
            try
            {
                _session.SaveOrUpdate(student);
            }
            catch (NHibernate.Exceptions.GenericADOException ex)
            {
                throw new Edutor.Data.Exceptions.DuplicateEntityException("This is a duplicate student, check the unique fields within your entity (Curp)");
            }
        }


        public Entities.Student ActivateStudent(string token)
        {
            var student = _session.QueryOver<Entities.Student>().Where(s => s.Token == token).SingleOrDefault();
            if (student == null)
            {
                throw new Edutor.Data.Exceptions.ObjectNotFoundException("El estudiante con el token " + token + " no existe en el sistema");
            }
            student.IsActive = true;
            _session.Update(student);
            return student;
        }
    }
}
