using Edutor.Web.Api.Models;
using Return = Edutor.Web.Api.Models.ReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edutor.Web.Api.Models;
using Edutor.Data;
using Edutor.Data.QueryProcessors;
using Edutor.Common.TypeMapping;
using Edutor.Web.Api.LinkServices;

namespace Edutor.Web.Api.InquiryProcessing
{
    public interface IGetEventsInquiryProcessor
    {

        PagedDataResponse<Return.Event> GetEventsForSchoolUser(int schoolUserId, PagedDataRequest request);

        PagedDataResponse<Return.Event> GetEventsForStudent(int studentId, PagedDataRequest requestInfo);

        Return.Event GetEvent(int eventId);
    }

    public class GetEventsInquiryProcessor : IGetEventsInquiryProcessor
    {

        private readonly IAutoMapper _autoMapper;
        private readonly IGetEventsQueryProcessor _queryProcessor;
        private readonly IEventsLinkService _notifLinkService;
        private readonly ICommonLinkService _commonLinkService;

        public GetEventsInquiryProcessor(IAutoMapper autoMapper,
            IGetEventsQueryProcessor queryProcessor,
            IEventsLinkService notifLinkService,
            ICommonLinkService commonLinkService)
        {
            _autoMapper = autoMapper;
            _queryProcessor = queryProcessor;
            _notifLinkService = notifLinkService;
            _commonLinkService = commonLinkService;
        }

        public Models.PagedDataResponse<Return.Event> GetEventsForSchoolUser(int schoolUserId, PagedDataRequest request)
        {
            var qresult = _queryProcessor.GetEventsForSchoolUser(schoolUserId, request);

            var inquiryResponse = new PagedDataResponse<Return.Event>
            {
                Items = CastCollection(qresult),
                PageCount = qresult.TotalPageCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            _commonLinkService.AddPageLinks(inquiryResponse);

            return inquiryResponse;
        }
        public Models.PagedDataResponse<Return.Event> GetEventsForStudent(int studentId, PagedDataRequest requestInfo)
        {
            var qresult = _queryProcessor.GetEventsForStudent(studentId, requestInfo);

            var inquiryResponse = new PagedDataResponse<Return.Event>
            {
                Items = CastCollection(qresult),
                PageCount = qresult.TotalPageCount,
                PageNumber = requestInfo.PageNumber,
                PageSize = requestInfo.PageSize
            };

            _commonLinkService.AddPageLinks(inquiryResponse);

            return inquiryResponse;
        }


        public Return.Event GetEvent(int eventId)
        {
            var r = _queryProcessor.GetEvent(eventId);
            var t = _autoMapper.Map<Return.Event>(r);
            _notifLinkService.AddAllLinks(t);
            return t;
        }


        private List<Return.Event> CastCollection(QueryResult<Data.Entities.Event> qresult)
        {
            var x = qresult.QueriedItems.Select(r => _autoMapper.Map<Return.Event>(r)).ToList();
            x.ForEach(t => _notifLinkService.AddAllLinks(t));
            return x;
        }


    }
}
