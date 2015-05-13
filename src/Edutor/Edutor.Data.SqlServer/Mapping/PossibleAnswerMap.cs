using Edutor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.SqlServer.Mapping
{
    public class PossibleAnswerMap : VersionedClassMap<PossibleAnswer>
    {
        public InvitationMap()
        {
            Table("PossibleAnswers");
            Map(entityName => entityName.Text);
            CompositeId().KeyReference(l => l.Question, "QuestionID").KeyProperty(q=> q.PossibleAnswerId);
            //References<Event>(x => x.Event).Column("EventId");
            //References<Student>(x => x.Student).Column("StudentId");
        }
    }
}
