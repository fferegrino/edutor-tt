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
            Map(x => x.From);
            Map(x => x.To);

            // TODO Add references and mappings
        }
    }
}
