using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.Entities
{
    public class User : IVersionedEntity
    {
        public virtual int UserId { get; set; }
        public virtual char Type { get; set; }
        public virtual string Name { get; set; }
        public virtual string Curp { get; set; }
        public virtual string Email { get; set; }
        public virtual string Address { get; set; }
        public virtual string Mobile { get; set; }
        public virtual string Phone { get; set; }

        #region SchoolUser
        public virtual Nullable<char> Position { get; set; }
        public virtual IList<Group> Groups { get; set; }
        #endregion

        #region Tutor
        public virtual IList<Student> Students { get; set; }
        public virtual string Job { get; set; }
        public virtual string JobTelephone { get; set; }
        #endregion


        public virtual byte[] Version { get; set; }

        #region User types
        public const char SchoolUserType = 'E';
        public const char TutorType = 'T';
        public const char ProfessorPosition = 'P'; 
        public const char AdministrativePosition = 'A';
        #endregion
    }
}
