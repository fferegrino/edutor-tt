using Edutor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.SqlServer.Mapping
{
    public class AnswerMap : VersionedClassMap<Answer>
    {
        public AnswerMap()
        {
            Table("Answers");
            Map(entityName => entityName.AnswerDate);
            Map(entityName => entityName.ActualAnswerId);
            CompositeId().KeyReference(l => l.Student, "StudentId").KeyReference(l => l.Question, "QuestionId");
            //HasOne<PossibleAnswer>(x => x.ActualAnswer);
            //References<PossibleAnswer>(x => x.ActualAnswer).Columns("ActualAnswerId");
            //References<Event>(x => x.Event).Column("EventId");
            //References<Student>(x => x.Student).Column("StudentId");
        }
    }
}
