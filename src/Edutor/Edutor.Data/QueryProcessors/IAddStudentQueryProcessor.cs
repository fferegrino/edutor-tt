using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.QueryProcessors
{
    public interface IAddStudentQueryProcessor
    {
        void AddStudent(Entities.Student student);

        Entities.Student ActivateStudent(string token);
    }
}
