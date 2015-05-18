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
    public interface IGetStudentsInquiryProcessor
    {

        PagedDataInquiryResponse<Return.Student> GetAllStudents(PagedDataRequest request);

        PagedDataInquiryResponse<Return.Student> GetStudentsForGroup(int groupId, PagedDataRequest requestInfo);

        PagedDataInquiryResponse<Return.Student> GetStudentsForTutor(int tutorId, PagedDataRequest requestInfo);

        PagedDataInquiryResponse<Return.Student> GetStudentsForNotification(int notificationId, PagedDataRequest requestInfo);

        PagedDataInquiryResponse<Return.Student> GetStudentsForEvent(int eventId, PagedDataRequest request);

        PagedDataInquiryResponse<Return.Student> GetStudentsForQuestion(int questionId, PagedDataRequest request);

        Return.Student GetStudent(int id);

        Return.Student GetStudent(string curp);

    }

    public class GetStudentsInquiryProcessor : IGetStudentsInquiryProcessor
    {

        private readonly IAutoMapper _autoMapper;
        private readonly IGetStudentsQueryProcessor _queryProcessor;
        private readonly IStudentsLinkService _linkServices;
        private readonly ICommonLinkService _commonLinkService;
        public GetStudentsInquiryProcessor(IAutoMapper autoMapper,
            IGetStudentsQueryProcessor queryProcessor,
            ICommonLinkService commonLinkService,
            IStudentsLinkService tutorsLinkService)
        {
            _autoMapper = autoMapper;
            _queryProcessor = queryProcessor;
            _commonLinkService = commonLinkService;
            _linkServices = tutorsLinkService;
        }

        public PagedDataInquiryResponse<Return.Student> GetAllStudents(PagedDataRequest request)
        {
            var qresult = _queryProcessor.GetStudents(request);
            var returnUsers = GetCollection(qresult);
            var inquiryResponse = new PagedDataInquiryResponse<Return.Student>
            {
                Items = returnUsers,
                PageCount = qresult.TotalPageCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            _commonLinkService.AddPageLinks(inquiryResponse);

            return inquiryResponse;
        }

        public PagedDataInquiryResponse<Return.Student> GetStudentsForTutor(int tutorId, PagedDataRequest requestInfo)
        {
            var qresult = _queryProcessor.GetStudentsForTutor(tutorId, requestInfo);
            var returnUsers = GetCollection(qresult);
            var inquiryResponse = new PagedDataInquiryResponse<Return.Student>
            {
                Items = returnUsers,
                PageCount = qresult.TotalPageCount,
                PageNumber = requestInfo.PageNumber,
                PageSize = requestInfo.PageSize
            };

            _commonLinkService.AddPageLinks(inquiryResponse);

            return inquiryResponse;
        
        }

        public PagedDataInquiryResponse<Return.Student> GetStudentsForNotification(int notificationId, PagedDataRequest requestInfo)
        {
            var qresult = _queryProcessor.GetStudentsForNotification(notificationId, requestInfo);
            var returnUsers = GetCollection(qresult);
            var inquiryResponse = new PagedDataInquiryResponse<Return.Student>
            {
                Items = returnUsers,
                PageCount = qresult.TotalPageCount,
                PageNumber = requestInfo.PageNumber,
                PageSize = requestInfo.PageSize
            };

            _commonLinkService.AddPageLinks(inquiryResponse);

            return inquiryResponse;

        }

        public PagedDataInquiryResponse<Return.Student> GetStudentsForGroup(int groupId,PagedDataRequest request)
        {
            var qresult = _queryProcessor.GetStudentsForGroup(groupId,request);
            var returnUsers = GetCollection(qresult);
            var inquiryResponse = new PagedDataInquiryResponse<Return.Student>
            {
                Items = returnUsers,
                PageCount = qresult.TotalPageCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            _commonLinkService.AddPageLinks(inquiryResponse);

            return inquiryResponse;
        }
        public PagedDataInquiryResponse<Return.Student> GetStudentsForQuestion(int questionId, PagedDataRequest request)
        {
            var qresult = _queryProcessor.GetStudentsForQuestion(questionId, request);
            var returnUsers = GetCollection(qresult);
            var inquiryResponse = new PagedDataInquiryResponse<Return.Student>
            {
                Items = returnUsers,
                PageCount = qresult.TotalPageCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            _commonLinkService.AddPageLinks(inquiryResponse);

            return inquiryResponse;
        }

        public PagedDataInquiryResponse<Return.Student> GetStudentsForEvent(int eventId, PagedDataRequest request)
        {
            var qresult = _queryProcessor.GetStudentsForEvent(eventId, request);
            var returnUsers = GetCollection(qresult);
            var inquiryResponse = new PagedDataInquiryResponse<Return.Student>
            {
                Items = returnUsers,
                PageCount = qresult.TotalPageCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            _commonLinkService.AddPageLinks(inquiryResponse);

            return inquiryResponse;
        }

        private List<Return.Student> GetCollection(QueryResult<Data.Entities.Student> qresult)
        {
            var x = qresult.QueriedItems.Select(r => _autoMapper.Map<Return.Student>(r)).ToList();
            x.ForEach(t =>
            {
                _linkServices.AddAllLinks(t);
            });
            return x;
        }


        public Return.Student GetStudent(int id)
        {
            var r = _queryProcessor.GetStudent(id);
            var t = _autoMapper.Map<Return.Student>(r);
            _linkServices.AddAllLinks(t);
            return t;
        }

        public Return.Student GetStudent(string curp)
        {
            var r = _queryProcessor.GetStudent(curp);
            var t = _autoMapper.Map<Return.Student>(r);
            _linkServices.AddAllLinks(t);
            return t;
        }
    }
}
