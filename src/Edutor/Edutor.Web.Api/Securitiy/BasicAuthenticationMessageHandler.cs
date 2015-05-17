using Edutor.Common;
using Edutor.Common.Logging;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Edutor.Web.Api.Securitiy
{
    public class BasicAuthenticationMessageHandler : DelegatingHandler
    {
        public const char AuthorizationHeaderSeparator = ':';
        public const int UserTypeIndex = 0;
        public const int UserIndex = 2;
        public const int PasswordIndex = 1;
        public const int TutorExpectedCredentialCount = 2;
        public const int SchoolUserExpectedCredentialCount = 3;

        private readonly ILog _log;
        private readonly IBasicSecurityService _basicSecurityService;

        public BasicAuthenticationMessageHandler(ILogManager logManager, IBasicSecurityService basicSecurityService)
        {
            _basicSecurityService = basicSecurityService;
            _log = logManager.GetLog(typeof(BasicAuthenticationMessageHandler));
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                _log.Debug("Auth, next handler...");
                return await base.SendAsync(request, cancellationToken);
            }

            if (!CanHandleAuth(request))
            {
                _log.Debug("Not a basic auth request");
                return await base.SendAsync(request, cancellationToken);
            }

            bool isAuth;

            try
            {
                isAuth = Auth(request);
            }
            catch (Exception e)
            {
                _log.Error("Faliure in auth processing", e);

                return CreateUnauthorizedResponse();
            }

            if (isAuth)
            {
                var rsp = await base.SendAsync(request, cancellationToken);
                return rsp.StatusCode == System.Net.HttpStatusCode.Unauthorized ? CreateUnauthorizedResponse() : rsp;
            }

            return CreateUnauthorizedResponse();
        }

        private HttpResponseMessage CreateUnauthorizedResponse()
        {
            var response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            response.Headers.WwwAuthenticate.Add(
                new AuthenticationHeaderValue(Constants.SchemeTypes.Basic));
            return response;
        }

        private bool Auth(HttpRequestMessage request)
        {
            _log.Debug("Attempting to authenticate...");

            var authHeader = request.Headers.Authorization;
            if (authHeader == null)
            {
                return false;
            }

            var credentialParts = GetCredentialParts(authHeader);
            if (credentialParts.Length == TutorExpectedCredentialCount)
            {
                return _basicSecurityService.SetPrincipal(credentialParts[UserTypeIndex][0], credentialParts[PasswordIndex]);
            }
            else if (credentialParts.Length == SchoolUserExpectedCredentialCount)
            {
                return _basicSecurityService.SetPrincipal(credentialParts[UserTypeIndex][0], credentialParts[PasswordIndex], Int32.Parse(credentialParts[UserIndex]));
            }

            return false;
        }

        private string[] GetCredentialParts(System.Net.Http.Headers.AuthenticationHeaderValue authHeader)
        {
            var encodedCredentials = authHeader.Parameter;
            var credentialBytes = Convert.FromBase64String(encodedCredentials);
            var credentials = Encoding.ASCII.GetString(credentialBytes);
            var credentialParts = credentials.Split(AuthorizationHeaderSeparator);
            return credentialParts;
        }

        private bool CanHandleAuth(HttpRequestMessage request)
        {
            return (request.Headers != null
                && request.Headers.Authorization != null
                && request.Headers.Authorization.Scheme.Equals(Constants.SchemeTypes.Basic, StringComparison.OrdinalIgnoreCase));
        }
    }
}
