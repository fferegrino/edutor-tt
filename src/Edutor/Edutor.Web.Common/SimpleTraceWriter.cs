using Edutor.Common.Logging;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Tracing;

namespace Edutor.Web.Common
{
    public class SimpleTraceWriter : ITraceWriter
    {
        private readonly ILog _log;

        public SimpleTraceWriter(ILogManager logManager)
        {
            _log = logManager.GetLog(typeof(SimpleTraceWriter));
        }

        public void Trace(System.Net.Http.HttpRequestMessage request, string category, TraceLevel level, Action<TraceRecord> traceAction)
        {
            var rec = new TraceRecord(request, category, level);
            traceAction(rec);
            WriteTrace(rec);
        }

        private void WriteTrace(TraceRecord rec)
        {
            const string TraceFormat = 
                "RequestId={1};{0}Kind={2};{0}Status={3};" + 
                "{0}Operation={4};{0}Operator={5};{0}Category={6};" + 
                "{0}Request={7};{0}Message={8}";

            var args = new object[] 
            { 
                Environment.NewLine,
                rec.RequestId,
                rec.Kind,
                rec.Status,
                rec.Operation,
                rec.Operator,
                rec.Category,
                rec.Request,
                rec.Message
            };

            switch (rec.Level)
            {
                case TraceLevel.Debug:
                    _log.DebugFormat(TraceFormat, args);
                    break;
                case TraceLevel.Info:
                    _log.InfoFormat(TraceFormat, args);
                    break;
                case TraceLevel.Warn:
                    _log.WarnFormat(TraceFormat, args);
                    break;
                case TraceLevel.Error:
                    _log.ErrorFormat(TraceFormat, args);
                    break;
                case TraceLevel.Fatal:
                    _log.FatalFormat(TraceFormat, args);
                    break;
            }

        }
    }
}
