using Edutor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.SqlServer.Mapping
{
    public class QuestionMap : VersionedClassMap<Question>
    {
        public QuestionMap()
        {
            Table("Questions");
            Id(x => x.QuestionId);
            References<SchoolUser>(x => x.SchoolUser);
        }
    }
}
