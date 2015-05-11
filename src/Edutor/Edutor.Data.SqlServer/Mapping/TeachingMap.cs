using Edutor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.SqlServer.Mapping
{
    public class TeachingMap : VersionedClassMap<Teaching>
    {
        public TeachingMap()
        {
            Table("Teachings");
            CompositeId()
                .KeyReference(x => x.SchoolUser, "SchoolUserId")
                .KeyReference(x => x.Group, "GroupId");


            // TODO Add references and mappings
        }
    }
}
