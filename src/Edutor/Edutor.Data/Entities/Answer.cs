using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.Entities
{
    public class Answer : IVersionedEntity
    {
        public virtual int StudentId { get; set; }
        public virtual int QuestionId { get; set; }
        public virtual int? ActualAnswerId { get; set; }
        public virtual DateTime? AnswerDate { get; set; }
        //public virtual bool? Rsvp { get; set; }

        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Answer p = obj as Answer;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (QuestionId == p.QuestionId) && (StudentId == p.StudentId);
        }

        public override int GetHashCode()
        {
            return QuestionId ^ StudentId;
        }

        public virtual Question Question{ get; set; }
        public virtual Student Student { get; set; }

        public virtual PossibleAnswer ActualAnswer { get; set; }
        public virtual byte[] Version { get; set; }
    }
}
