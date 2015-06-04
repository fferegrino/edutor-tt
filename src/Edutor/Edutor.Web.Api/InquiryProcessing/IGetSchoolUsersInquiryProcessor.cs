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
    public interface IGetSchoolUsersInquiryProcessor
    {

        PagedDataResponse<Return.SchoolUser> GetAllSchoolUsers(PagedDataRequest request);
        PagedDataResponse<Return.SchoolUser> GetSchoolUsersForGroup(int groupId, PagedDataRequest request);
        PagedDataResponse<Return.SchoolUser> GetTeachersForStudent(int studentId, PagedDataRequest request);
        Return.SchoolUser GetSchoolUser(int userId);

        Return.SchoolUser GetSchoolUser(string curp);
    }

    public class GetSchoolUsersInquiryProcessor : IGetSchoolUsersInquiryProcessor
    {

        private readonly IAutoMapper _autoMapper;
        private readonly IGetUsersQueryProcessor _queryProcessor;
        private readonly ISchoolUsersLinkService _tutorsLinkService;
        private readonly ICommonLinkService _commonLinkService;
        public GetSchoolUsersInquiryProcessor(IAutoMapper autoMapper, 
            ISchoolUsersLinkService tutorsLinkService,
            IGetUsersQueryProcessor queryProcessor, 
            ICommonLinkService commonLinkService)
        {
            _autoMapper = autoMapper;
            _queryProcessor = queryProcessor;
            _commonLinkService = commonLinkService;
            _tutorsLinkService = tutorsLinkService;
        }
        public PagedDataResponse<Return.SchoolUser> GetAllSchoolUsers(PagedDataRequest request)
        {
            var qresult = _queryProcessor.GetSchoolUsers(request);
            var returnUsers = GetSchoolUsers(qresult);
            var inquiryResponse = new PagedDataResponse<Return.SchoolUser>
            {
                Items = returnUsers,
                PageCount = qresult.TotalPageCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            _commonLinkService.AddPageLinks(inquiryResponse);

            return inquiryResponse;
        }

        public PagedDataResponse<Return.SchoolUser> GetSchoolUsersForGroup(int groupId,PagedDataRequest request)
        {
            var qresult = _queryProcessor.GetSchoolUsersForGroup(groupId, request);
            var returnUsers = GetSchoolUsers(qresult);
            var inquiryResponse = new PagedDataResponse<Return.SchoolUser>
            {
                Items = returnUsers,
                PageCount = qresult.TotalPageCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            _commonLinkService.AddPageLinks(inquiryResponse);

            return inquiryResponse;
        }

        private List<Return.SchoolUser> GetSchoolUsers(QueryResult<Data.Entities.User> qresult)
        {
            var x = qresult.QueriedItems.Select(r => _autoMapper.Map<Return.SchoolUser>(r)).ToList();
            x.ForEach(t => _tutorsLinkService.AddAllLinks(t));
            return x;
        }


        private List<Return.SchoolUser> GetSchoolUsers(QueryResult<Data.Entities.TeacherForStudent> qresult)
        {
            var x = qresult.QueriedItems.Select(r => _autoMapper.Map<Return.SchoolUser>(r)).ToList();
            x.ForEach(t => _tutorsLinkService.AddAllLinks(t));
            return x;
        }


        public Return.SchoolUser GetSchoolUser(int userId)
        {
            var s = _queryProcessor.GetSchoolUser(userId);
            var returnType = _autoMapper.Map<Return.SchoolUser>(s);
            _tutorsLinkService.AddAllLinks(returnType);
            return returnType;
        }

        public Return.SchoolUser GetSchoolUser(string curp)
        {
            var s = _queryProcessor.GetSchoolUser(curp);
            var returnType = _autoMapper.Map<Return.SchoolUser>(s);
            _tutorsLinkService.AddAllLinks(returnType);
            return returnType;
        }


        public PagedDataResponse<Return.SchoolUser> GetTeachersForStudent(int studentId, PagedDataRequest request)
        {
            var qresult = _queryProcessor.GetTeachersForStudent(studentId, request);
            var returnUsers = GetSchoolUsers(qresult);
            var inquiryResponse = new PagedDataResponse<Return.SchoolUser>
            {
                Items = returnUsers,
                PageCount = qresult.TotalPageCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            _commonLinkService.AddPageLinks(inquiryResponse);

            return inquiryResponse;
        }
    }
}

