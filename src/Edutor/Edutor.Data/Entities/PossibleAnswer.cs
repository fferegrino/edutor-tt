using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.Entities
{
    public class PossibleAnswer : IVersionedEntity
    {
        public virtual int QuestionId { get; set; }
        public virtual int PossibleAnswerId { get; set; }
        public virtual string Text { get; set; }

        public virtual Question Question { get; set; }


        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            PossibleAnswer p = obj as PossibleAnswer;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (QuestionId == p.QuestionId) && (PossibleAnswerId == p.PossibleAnswerId);
        }

        public override int GetHashCode()
        {
            return QuestionId ^ PossibleAnswerId;
        }

        public virtual byte[] Version { get; set; }
    }
}
