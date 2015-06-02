using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Edutor.Web.Common
{
    public class RemoveHeadersModule : IHttpModule, IDisposable
    {
        private HttpApplication _httpApplication;
        private static readonly List<string> HeadersToCloak = new List<string>
            {
                "Server",
                "X-AspNet-Version",
                "X-AspNetMvc-Version",
                "X-Powered-By"
            };


        public void Dispose()
        {
            _httpApplication.Dispose();
        }

        public void Init(HttpApplication context)
        {
            _httpApplication = context;

            context.PreSendRequestHeaders += OnPreSendRequestHeaders;
        }

        private void OnPreSendRequestHeaders(object sender, EventArgs e)
        {
            if (null == _httpApplication)
            {
                return;
            }

            if (_httpApplication.Context != null)
            {
                var response = _httpApplication.Response;
                HeadersToCloak.ForEach(header => response.Headers.Remove(header));
            }

        }
    }

}
