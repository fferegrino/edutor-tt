using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.Entities
{
    public class TutorForTeacher : User
    {
        public virtual int TutorId { get; set; }
        public virtual int TeacherId { get; set; }
        public virtual int GroupId { get; set; }
        public virtual string GroupName { get; set; }
    }
}
