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
    public interface IGetQuestionsInquiryProcessor
    {

        PagedDataResponse<Return.Question> GetQuestionsForSchoolUser(int schoolUserId, PagedDataRequest request);

        PagedDataResponse<Return.Question> GetQuestionsForStudent(int studentId, PagedDataRequest requestInfo);

        Return.Question GetQuestion(int questionId);
    }

    public class GetQuestionsInquiryProcessor : IGetQuestionsInquiryProcessor
    {

        private readonly IAutoMapper _autoMapper;
        private readonly IGetQuestionsQueryProcessor _queryProcessor;
        private readonly IQuestionsLinkService _notifLinkService;
        private readonly ICommonLinkService _commonLinkService;

        public GetQuestionsInquiryProcessor(IAutoMapper autoMapper,
            IGetQuestionsQueryProcessor queryProcessor,
            IQuestionsLinkService notifLinkService,
            ICommonLinkService commonLinkService)
        {
            _autoMapper = autoMapper;
            _queryProcessor = queryProcessor;
            _notifLinkService = notifLinkService;
            _commonLinkService = commonLinkService;
        }

        public Models.PagedDataResponse<Return.Question> GetQuestionsForSchoolUser(int schoolUserId, PagedDataRequest request)
        {
            var qresult = _queryProcessor.GetQuestionsForSchoolUser(schoolUserId, request);

            var inquiryResponse = new PagedDataResponse<Return.Question>
            {
                Items = CastCollection(qresult),
                PageCount = qresult.TotalPageCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            _commonLinkService.AddPageLinks(inquiryResponse);

            return inquiryResponse;
        }

        public PagedDataResponse<Return.Question> GetQuestionsForStudent(int studentId, PagedDataRequest request)
        {
            var qresult = _queryProcessor.GetQuestionsForStudent(studentId, request);

            var inquiryResponse = new PagedDataResponse<Return.Question>
            {
                Items = CastCollection(qresult),
                PageCount = qresult.TotalPageCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            _commonLinkService.AddPageLinks(inquiryResponse);

            return inquiryResponse;
        }

        private List<Return.Question> CastCollection(QueryResult<Data.Entities.Question> qresult)
        {
            var x = qresult.QueriedItems.Select(r => _autoMapper.Map<Return.Question>(r)).ToList();
            x.ForEach(t => _notifLinkService.AddAllLinks(t));
            return x;
        }

        public Return.Question GetQuestion(int questionId)
        {
            var r = _queryProcessor.GetQuestion(questionId);
            var t = _autoMapper.Map<Return.Question>(r);
            _notifLinkService.AddAllLinks(t);
            return t;
        }




    }
}
