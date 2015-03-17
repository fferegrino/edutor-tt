using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Common
{
    public interface IDateTime
    {
        DateTime UtcNow { get; }
    }

    public class DateTimeAdapter : IDateTime
    {

        public DateTime UtcNow
        {
            get { return DateTime.UtcNow; }
        }
    }
}
