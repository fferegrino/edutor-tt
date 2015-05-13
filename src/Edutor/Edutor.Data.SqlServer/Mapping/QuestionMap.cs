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
            Map(x => x.Text);
            Map(x => x.ExpirationDate);
            References<User>(x => x.SchoolUser).Column("SchoolUserId");
            HasMany<PossibleAnswer>(ev => ev.PossibleAnswers).KeyColumn("QuestionId");
            HasMany<Answer>(ev => ev.Answers).KeyColumn("QuestionId");
        }
    }
}
