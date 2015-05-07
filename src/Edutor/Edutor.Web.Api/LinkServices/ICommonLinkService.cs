using Edutor.Common;
using Edutor.Common.Security;
using Edutor.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.LinkServices
{
    public interface ICommonLinkService
    {
        // TODO Implement AddPageLinks (page 196)

        Link GetLink(string pathFragment, string relValue, HttpMethod httpMethod);
    }

    public class CommonLinkService : ICommonLinkService
    {
        private readonly IWebUserSession _userSession;

        public CommonLinkService(IWebUserSession userSession)
        {
            _userSession = userSession;
        }

        public Link GetLink(string pathFragment, string relValue, HttpMethod httpMethod)
        {
            const string algo = Constants.CommonRoutingDefinitions.ApiSegmentName + "/{0}/";

            var path = pathFragment;
                //String.Concat(
                //    String.Format(algo,_userSession.ApiVersionInUse)
                //    ,pathFragment);{

            var uriBuilder = new UriBuilder{
                Scheme = _userSession.RequestUri.Scheme,
                Host = _userSession.RequestUri.Host,
                Port = _userSession.RequestUri.Port,
                Path = path
            };


            var link = new Link
            {
                Href = uriBuilder.Uri.AbsoluteUri,
                Rel = relValue,
                Method = httpMethod.Method
            };

            return link;
        }
    }
}
