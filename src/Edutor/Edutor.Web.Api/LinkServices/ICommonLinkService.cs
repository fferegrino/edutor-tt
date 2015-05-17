using Edutor.Common;
using Edutor.Common.Extensions;
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

        void AddPageLinks(IPageLinkContaining linkContainer);
        //,string currentPageQ
        //,string previousPageQ
        //,string nextPageQ);
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

            var uriBuilder = new UriBuilder
            {
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


        public void AddPageLinks(IPageLinkContaining linkContainer/*, string currentPageQ, string previousPageQ, string nextPageQ*/)
        {
            var baseUri = _userSession.RequestUri.GetBaseUri();
            AddCurrentPageLink(linkContainer, baseUri,
                String.Format(Constants.Paging.PagedQueryStringFormat, linkContainer.PageNumber, linkContainer.PageSize)); // <- Current page link
            var addPrevLink = ShouldAddPreviousPageLink(linkContainer.PageNumber);
            var addNextLink = ShouldAddNextPageLink(linkContainer.PageNumber, linkContainer.PageCount);

            if (addPrevLink || addNextLink)
            {
                if (addPrevLink)
                    AddPreviousPageLink(linkContainer, baseUri,
                        String.Format(Constants.Paging.PagedQueryStringFormat, linkContainer.PageNumber - 1, linkContainer.PageSize));

                if (addNextLink)
                    AddNextPageLink(linkContainer, baseUri,
                        String.Format(Constants.Paging.PagedQueryStringFormat, linkContainer.PageNumber + 1, linkContainer.PageSize));
            }
        }

        private void AddCurrentPageLink(IPageLinkContaining linkContainer, Uri baseUri, string currentPageQ)
        {
            var current = new UriBuilder(baseUri)
            {
                Query = currentPageQ
            };
            linkContainer.AddLink(new Link
            {
                Href = current.Uri.AbsoluteUri,
                Rel = Constants.CommonLinkRelValues.CurrentPage,
                Method = HttpMethod.Get.Method
            });
        }

        private void AddNextPageLink(IPageLinkContaining linkContainer, Uri baseUri, string previousPageQ)
        {

            var current = new UriBuilder(baseUri)
            {
                Query = previousPageQ
            };
            linkContainer.AddLink(new Link
            {
                Href = current.Uri.AbsoluteUri,
                Rel = Constants.CommonLinkRelValues.NextPage,
                Method = HttpMethod.Get.Method
            });
        }

        private void AddPreviousPageLink(IPageLinkContaining linkContainer, Uri baseUri, string previousPageQ)
        {
            var current = new UriBuilder(baseUri)
            {
                Query = previousPageQ
            };
            linkContainer.AddLink(new Link
            {
                Href = current.Uri.AbsoluteUri,
                Rel = Constants.CommonLinkRelValues.PreviousPage,
                Method = HttpMethod.Get.Method
            });
        }

        private bool ShouldAddNextPageLink(int pageNumber, int pageCount)
        {
            return pageNumber < pageCount;
        }

        private bool ShouldAddPreviousPageLink(int pageNumber)
        {
            return pageNumber > 1;
        }
    }
}