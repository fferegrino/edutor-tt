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
            //References<PossibleAnswer>(x=> x.ActualAnswer).Columns("QuestionId", "ActualAnswerId");
            CompositeId().KeyReference(l => l.Student, "StudentId").KeyReference(l => l.Question, "QuestionId");
            //References<Event>(x => x.Event).Column("EventId");
            //References<Student>(x => x.Student).Column("StudentId");
        }
    }
}
