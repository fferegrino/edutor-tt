using Edutor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.SqlServer.Mapping
{
    public class UserMap : VersionedClassMap<User>
    {
        public UserMap()
        {
            Table("Users");
            Id(x => x.UserId);
            Map(x => x.Type).Not.Nullable();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Curp).Not.Nullable();
            Map(x => x.Email).Not.Nullable();
            Map(x => x.Address).Not.Nullable();
            Map(x => x.Mobile).Nullable();
            Map(x => x.Phone).Nullable();
            Map(x => x.Job).Nullable();
            Map(x => x.JobTelephone).Nullable();
            Map(x => x.Position).Nullable();
            Map(x => x.Password).Nullable();


            HasManyToMany(x => x.Groups).Table("Teachings")
                                   .ParentKeyColumn("GroupId")
                                   .ChildKeyColumn("SchoolUserId");
            
        }
    }

    public class TeacherForStudentMap : VersionedClassMap<TeacherForStudent>
    {
        public TeacherForStudentMap()
        {
            Table("TeacherForStudents");
            ReadOnly();
            Id(x => x.UserId);
            Map(x => x.Type).Not.Nullable();
            Map(x => x.StudentId).Not.Nullable();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Curp).Not.Nullable();
            Map(x => x.Email).Not.Nullable();
            Map(x => x.Address).Not.Nullable();
            Map(x => x.Mobile).Nullable();
            Map(x => x.Phone).Nullable();
            Map(x => x.Job).Nullable();
            Map(x => x.JobTelephone).Nullable();
            Map(x => x.Position).Nullable();
            Map(x => x.Password).Nullable();


            HasManyToMany(x => x.Groups).Table("Teachings")
                                   .ParentKeyColumn("GroupId")
                                   .ChildKeyColumn("SchoolUserId");

        }
    }


    public class TutorForTeacherMap : VersionedClassMap<TutorForTeacher>
    {
        public TutorForTeacherMap()
        {
            Table("TutorsForTeachers");
            ReadOnly();
            Id(x => x.UserId);
            Map(x => x.Type).Not.Nullable();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Curp).Not.Nullable();
            Map(x => x.Email).Not.Nullable();
            Map(x => x.Address).Not.Nullable();
            Map(x => x.Mobile).Nullable();
            Map(x => x.Phone).Nullable();
            Map(x => x.Job).Nullable();
            Map(x => x.JobTelephone).Nullable();
            Map(x => x.Position).Nullable();
            Map(x => x.Password).Nullable();



            Map(x => x.TeacherId).Not.Nullable();
            Map(x => x.GroupId).Not.Nullable();
            Map(x => x.GroupName).Not.Nullable();
            Map(x => x.TutorId).Not.Nullable();

            HasManyToMany(x => x.Groups).Table("Teachings")
                                   .ParentKeyColumn("GroupId")
                                   .ChildKeyColumn("SchoolUserId");

        }
    }
}
