using Edutor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.SqlServer.Mapping
{
    public class GroupMap : VersionedClassMap<Group>
    {
        public GroupMap()
        {
            Table("Groups");
            Id(x => x.GroupId);
            Map(x => x.Name);
            Map(x => x.Subject);
            Map(x => x.FromDate);
            Map(x => x.ToDate);


            HasManyToMany(x => x.Teachers).Table("Teachings")
                       //.ParentKeyColumn("SchoolUserId")
                       //.ChildKeyColumn("GroupId")
                       .ParentKeyColumn("GroupId")
                       .ChildKeyColumn("SchoolUserId")
                       .Inverse();

            HasManyToMany(x => x.Students).Table("Enrollments")
                       //.ParentKeyColumn("StudentId")
                       //.ChildKeyColumn("GroupId")
                       .ParentKeyColumn("GroupId")
                       .ChildKeyColumn("StudentId")
                       .Inverse();

            // TODO Add references and mappings
        }
    }
}
