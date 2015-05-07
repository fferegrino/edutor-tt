using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.Entities
{
    public class Question : IVersionedEntity
    {
        public virtual int QuestionId { get; set; }

        public virtual int SchoolUserId { get; set; }

        public virtual User SchoolUser { get; set; }

        public virtual string Text { get; set; }

        public virtual DateTime ExpirationDate { get; set; }

        public virtual byte[] Version { get; set; }
    }
}
