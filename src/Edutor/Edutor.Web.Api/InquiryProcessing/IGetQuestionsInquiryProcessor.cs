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

        PagedDataResponse<Return.StudentAnswer> GetQuestionsForStudent(int studentId, PagedDataRequest requestInfo);

        Return.Question GetQuestion(int questionId);
    }

    public class GetQuestionsInquiryProcessor : IGetQuestionsInquiryProcessor
    {

        private readonly IAutoMapper _autoMapper;
        private readonly IGetQuestionsQueryProcessor _queryProcessor;
        private readonly IQuestionsLinkService _notifLinkService;
        private readonly IElementsLinkService _basicLinksService;
        private readonly ICommonLinkService _commonLinkService;

        public GetQuestionsInquiryProcessor(IAutoMapper autoMapper,
            IGetQuestionsQueryProcessor queryProcessor,
            IQuestionsLinkService notifLinkService,
            IElementsLinkService basicLinksService,
            ICommonLinkService commonLinkService)
        {
            _autoMapper = autoMapper;
            _queryProcessor = queryProcessor;
            _notifLinkService = notifLinkService;
            _commonLinkService = commonLinkService;
            _basicLinksService = basicLinksService;
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

        public PagedDataResponse<Return.StudentAnswer> GetQuestionsForStudent(int studentId, PagedDataRequest request)
        {
            var qresult = _queryProcessor.GetQuestionsForStudent(studentId, request);

            var inquiryResponse = new PagedDataResponse<Return.StudentAnswer>
            {
                Items = CastAnswersToStudentAnswers(qresult),
                PageCount = qresult.TotalPageCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            _commonLinkService.AddPageLinks(inquiryResponse);

            return inquiryResponse;
        }



        private List<Return.StudentAnswer> CastAnswersToStudentAnswers(QueryResult<Data.Entities.Answer> qresult)
        {
            var x = qresult.QueriedItems.Select(r => _autoMapper.Map<Return.StudentAnswer>(r)).ToList();
            x.ForEach(t => _basicLinksService.AddAllLinks(t));
            return x;
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
