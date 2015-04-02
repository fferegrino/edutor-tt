using Edutor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.SqlServer.Mapping
{
    class SchoolUserMap : VersionedClassMap<SchoolUser>
    {
        public SchoolUserMap()
        {
            Table("SchoolUsers");
            Id(x => x.SchoolUserId);
            References<User>(x => x.User).Column("SchoolUserId");
        }
    }
}
