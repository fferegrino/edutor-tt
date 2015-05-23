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

        PagedDataResponse<Return.Student> GetAllStudents(PagedDataRequest request);

        PagedDataResponse<Return.Student> GetStudentsForGroup(int groupId, PagedDataRequest requestInfo);

        PagedDataResponse<Return.Student> GetStudentsForTutor(int tutorId, PagedDataRequest requestInfo, bool onlyActive = true);

        PagedDataResponse<Return.StudentNotification> GetStudentsForNotification(int notificationId, PagedDataRequest requestInfo);

        PagedDataResponse<Return.StudentInvitation> GetStudentsForEvent(int eventId, PagedDataRequest request);

        PagedDataResponse<Return.StudentAnswer> GetStudentsForQuestion(int questionId, PagedDataRequest request);

        Return.Student GetStudent(int id);

        Return.Student GetStudent(string curp);

        Return.StudentInvitation GetStudentsForEvent(int eventId, int studentId);

        Return.StudentAnswer GetStudentsForQuestion(int eventId, int studentId);

        Return.StudentNotification GetStudentsForNotification(int notificationId, int studentId);

    }

    public class GetStudentsInquiryProcessor : IGetStudentsInquiryProcessor
    {

        private readonly IAutoMapper _autoMapper;
        private readonly IGetStudentsQueryProcessor _queryProcessor;
        private readonly IStudentsLinkService _linkServices;
        private readonly IElementsLinkService _linkBasicServices;
        private readonly ICommonLinkService _commonLinkService;
        public GetStudentsInquiryProcessor(IAutoMapper autoMapper,
            IGetStudentsQueryProcessor queryProcessor,
            ICommonLinkService commonLinkService,
            IElementsLinkService linkBasicServices,
            IStudentsLinkService tutorsLinkService)
        {
            _autoMapper = autoMapper;
            _queryProcessor = queryProcessor;
            _commonLinkService = commonLinkService;
            _linkServices = tutorsLinkService;
            _linkBasicServices = linkBasicServices;
        }

        public PagedDataResponse<Return.Student> GetAllStudents(PagedDataRequest request)
        {
            var qresult = _queryProcessor.GetStudents(request);
            var returnUsers = GetCollection(qresult);
            var inquiryResponse = new PagedDataResponse<Return.Student>
            {
                Items = returnUsers,
                PageCount = qresult.TotalPageCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            _commonLinkService.AddPageLinks(inquiryResponse);

            return inquiryResponse;
        }

        public PagedDataResponse<Return.Student> GetStudentsForTutor(int tutorId, PagedDataRequest requestInfo, bool onlyActive = true)
        {
            var qresult = _queryProcessor.GetStudentsForTutor(tutorId, requestInfo, onlyActive);
            var returnUsers = GetCollection(qresult);
            var inquiryResponse = new PagedDataResponse<Return.Student>
            {
                Items = returnUsers,
                PageCount = qresult.TotalPageCount,
                PageNumber = requestInfo.PageNumber,
                PageSize = requestInfo.PageSize
            };

            _commonLinkService.AddPageLinks(inquiryResponse);

            return inquiryResponse;

        }

        public PagedDataResponse<Return.StudentNotification> GetStudentsForNotification(int notificationId, PagedDataRequest requestInfo)
        {
            var qresult = _queryProcessor.GetStudentsForNotification(notificationId, requestInfo);
            var returnUsers = GetStudentNotifications(qresult);
            var inquiryResponse = new PagedDataResponse<Return.StudentNotification>
            {
                Items = returnUsers,
                PageCount = qresult.TotalPageCount,
                PageNumber = requestInfo.PageNumber,
                PageSize = requestInfo.PageSize
            };

            _commonLinkService.AddPageLinks(inquiryResponse);

            return inquiryResponse;

        }

        public PagedDataResponse<Return.Student> GetStudentsForGroup(int groupId, PagedDataRequest request)
        {
            var qresult = _queryProcessor.GetStudentsForGroup(groupId, request);
            var returnUsers = GetCollection(qresult);
            var inquiryResponse = new PagedDataResponse<Return.Student>
            {
                Items = returnUsers,
                PageCount = qresult.TotalPageCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            _commonLinkService.AddPageLinks(inquiryResponse);

            return inquiryResponse;
        }
        public PagedDataResponse<Return.StudentAnswer> GetStudentsForQuestion(int questionId, PagedDataRequest request)
        {
            var qresult = _queryProcessor.GetStudentsForQuestion(questionId, request);
            var returnUsers = GetStudentAnswers(qresult);
            var inquiryResponse = new PagedDataResponse<Return.StudentAnswer>
            {
                Items = returnUsers,
                PageCount = qresult.TotalPageCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            _commonLinkService.AddPageLinks(inquiryResponse);

            return inquiryResponse;
        }

        public PagedDataResponse<Return.StudentInvitation> GetStudentsForEvent(int eventId, PagedDataRequest request)
        {
            var qresult = _queryProcessor.GetStudentsForEvent(eventId, request);
            var returnUsers = GetStudentInvitations(qresult);
            var inquiryResponse = new PagedDataResponse<Return.StudentInvitation>
            {
                Items = returnUsers,
                PageCount = qresult.TotalPageCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            _commonLinkService.AddPageLinks(inquiryResponse);

            return inquiryResponse;
        }

        private List<Return.StudentAnswer> GetStudentAnswers(QueryResult<Data.Entities.Answer> qresult)
        {
            var x = qresult.QueriedItems.Select(r => _autoMapper.Map<Return.StudentAnswer>(r)).ToList();
            x.ForEach(t =>
            {
                _linkBasicServices.AddAllLinks(t);
            });
            return x;
        }

        private List<Return.StudentNotification> GetStudentNotifications(QueryResult<Data.Entities.NotificationDetail> qresult)
        {
            var x = qresult.QueriedItems.Select(r => _autoMapper.Map<Return.StudentNotification>(r)).ToList();
            x.ForEach(t =>
            {
                _linkBasicServices.AddAllLinks(t);
            });
            return x;
        }

        private List<Return.StudentInvitation> GetStudentInvitations(QueryResult<Data.Entities.Invitation> qresult)
        {
            var x = qresult.QueriedItems.Select(r => _autoMapper.Map<Return.StudentInvitation>(r)).ToList();
            x.ForEach(t =>
            {
                _linkBasicServices.AddAllLinks(t);
            });
            return x;
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


        public Return.StudentInvitation GetStudentsForEvent(int eventId, int studentId)
        {
            var r = _queryProcessor.GetStudentsForEvent(eventId, studentId);
            var t = _autoMapper.Map<Return.StudentInvitation>(r);
            _linkBasicServices.AddAllLinks(t);
            return t;
        }

        public Return.StudentAnswer GetStudentsForQuestion(int questionId, int studentId)
        {
            var r = _queryProcessor.GetStudentsForQuestion(questionId, studentId);
            var t = _autoMapper.Map<Return.StudentAnswer>(r);
            _linkBasicServices.AddAllLinks(t);
            return t;
        }

        public Return.StudentNotification GetStudentsForNotification(int notificationId, int studentId)
        {
            var r = _queryProcessor.GetStudentsForNotification(notificationId, studentId);
            var t = _autoMapper.Map<Return.StudentNotification>(r);
            _linkBasicServices.AddAllLinks(t);
            return t;
        }
    }
}
