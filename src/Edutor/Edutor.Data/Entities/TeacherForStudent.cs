using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.Entities
{
    public class TeacherForStudent : User
    {
        public virtual int StudentId { get; set; }
    }
}
