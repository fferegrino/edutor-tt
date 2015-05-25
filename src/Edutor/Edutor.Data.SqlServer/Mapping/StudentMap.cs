using Edutor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.SqlServer.Mapping
{
    public class StudentMap : VersionedClassMap<Student>
    {
        public StudentMap()
        {
            Table("Students");
            Id(x => x.StudentId);
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Curp).Not.Nullable();
            Map(x => x.Address).Not.Nullable();
            Map(x => x.TutorRelationship).Not.Nullable();
            Map(x => x.IsActive).Nullable();
            Map(x => x.Phone).Nullable();
            Map(x => x.Token).Not.Nullable();

            References<User>(x => x.Tutor).Column("TutorId");

            HasManyToMany(x => x.Groups).Table("Enrollments")
                                   .ParentKeyColumn("GroupId")
                                   .ChildKeyColumn("StudentId");
        }

    }
}
