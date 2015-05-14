using Edutor.Common.Logging;
using Edutor.Common.Extensions;
using Edutor.Data;
using log4net;
using System;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edutor.Common;
using System.Web;

namespace Edutor.Web.Api.InquiryProcessing
{
    public interface IPagedDataRequestFactory
    {
        PagedDataRequest Create(Uri requestUri);
    }

    public class PagedDataRequestFactory : IPagedDataRequestFactory
    {
        public const int DefaultPageSize = 20;
        public const int MaxPageSize = 25;
        private readonly ILog _log;

        public PagedDataRequestFactory(ILogManager logManager)
        {
            _log = logManager.GetLog(typeof(PagedDataRequestFactory));
        }

        public PagedDataRequest Create(Uri requestUri)
        {
            int? pageNumber,
                pageSize;

            try
            {
                var valueCollection = requestUri.ParseQueryString();
                pageNumber = PrimitiveTypeParser.Parse<int?>(valueCollection[Constants.CommonParameterNames.PageNumber]);
                pageSize = PrimitiveTypeParser.Parse<int?>(valueCollection[Constants.CommonParameterNames.PageSize]);
            }
            catch (Exception e)
            {
                _log.Error("Error parsing input", e);
                throw new HttpException((int)HttpStatusCode.BadRequest, e.Message);
            }
            pageNumber = pageNumber.GetBoundedValue(Constants.Paging.DefaultPageNumber, Constants.Paging.MinPageNumber);
            pageSize= pageSize.GetBoundedValue(DefaultPageSize, Constants.Paging.MinPageSize, MaxPageSize);

            return new PagedDataRequest(pageNumber.Value, pageSize.Value);
        }
    }
}
