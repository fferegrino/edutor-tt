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
}
