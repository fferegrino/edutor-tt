﻿using Edutor.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Edutor.Web.Api.MaintenanceProcessing
{
    public class ModelDeletedActionResult : IHttpActionResult 
    {
        private readonly HttpRequestMessage _requestMessage;

        public ModelDeletedActionResult(HttpRequestMessage requestMessage)
        {
            _requestMessage = requestMessage;
        }

        public Task<HttpResponseMessage> ExecuteAsync(System.Threading.CancellationToken cancellationToken)
        {
            return System.Threading.Tasks.Task.FromResult(Execute());
        }

        private HttpResponseMessage Execute()
        {
            var resp = _requestMessage.CreateResponse(System.Net.HttpStatusCode.NoContent);
            return resp;
        }
    }
}
