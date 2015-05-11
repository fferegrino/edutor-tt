using Edutor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.SqlServer.Mapping
{
    public class EnrollmentMap : VersionedClassMap<Enrollment>
    {
        public EnrollmentMap()
        {
            Table("Enrollments");
            CompositeId()
                .KeyReference(x => x.Student, "StudentId")
                .KeyReference(x => x.Group, "GroupId");

            // TODO Add references and mappings
        }
    }
}
