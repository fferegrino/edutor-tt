using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.Entities
{
    public class PossibleAnswer : IVersionedEntity
    {
        public virtual byte[] Version { get; set; }
    }
}
