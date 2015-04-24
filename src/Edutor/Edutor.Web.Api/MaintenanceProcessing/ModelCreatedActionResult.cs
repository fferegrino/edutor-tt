using Edutor.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Edutor.Web.Api.MaintenanceProcessing
{
    public class ModelCreatedActionResult<T> : IHttpActionResult
        where T : ILinkContaining
    {
        private readonly T _created;
        private readonly HttpRequestMessage _requestMessage;

        public ModelCreatedActionResult(HttpRequestMessage requestMessage, T created)
        {
            _created = created;
            _requestMessage = requestMessage;
        }

        public Task<HttpResponseMessage> ExecuteAsync(System.Threading.CancellationToken cancellationToken)
        {
            return System.Threading.Tasks.Task.FromResult(Execute());
        }

        private HttpResponseMessage Execute()
        {
            var resp = _requestMessage.CreateResponse(System.Net.HttpStatusCode.Created, _created);
            resp.Headers.Location = _created.GetLocationLink();
            return resp;
        }
    }
}