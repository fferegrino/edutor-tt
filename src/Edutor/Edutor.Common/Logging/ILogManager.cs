using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Common.Logging
{
    public interface ILogManager
    {
        ILog GetLog(Type typeAssociatedWithRequestedLog);
    }

    public class LogManagerAdapter : ILogManager
    {

        public ILog GetLog(Type typeAssociatedWithRequestedLog)
        {
            return LogManager.GetLogger(typeAssociatedWithRequestedLog);
        }
    }
}
