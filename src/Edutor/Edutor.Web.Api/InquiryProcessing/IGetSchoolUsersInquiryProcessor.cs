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

        PagedDataInquiryResponse<Return.SchoolUser> GetAllSchoolUsers(PagedDataRequest request);

        Return.SchoolUser GetSchoolUser(int userId);
    }

    public class GetSchoolUsersInquiryProcessor : IGetSchoolUsersInquiryProcessor
    {

        private readonly IAutoMapper _autoMapper;
        private readonly IGetUsersQueryProcessor _queryProcessor;
        private readonly IUsersLinkService _tutorsLinkService;
        private readonly ICommonLinkService _commonLinkService;
        public GetSchoolUsersInquiryProcessor(IAutoMapper autoMapper, 
            IUsersLinkService tutorsLinkService,
            IGetUsersQueryProcessor queryProcessor, 
            ICommonLinkService commonLinkService)
        {
            _autoMapper = autoMapper;
            _queryProcessor = queryProcessor;
            _commonLinkService = commonLinkService;
            _tutorsLinkService = tutorsLinkService;
        }
        public PagedDataInquiryResponse<Return.SchoolUser> GetAllSchoolUsers(PagedDataRequest request)
        {
            var qresult = _queryProcessor.GetSchoolUsers(request);
            var returnUsers = GetSchoolUsers(qresult);
            var inquiryResponse = new PagedDataInquiryResponse<Return.SchoolUser>
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
            x.ForEach(t => _tutorsLinkService.AddSelfLink(t));
            return x;
        }


        public Return.SchoolUser GetSchoolUser(int userId)
        {
            var s = _queryProcessor.GetSchoolUser(userId);
            var returnType = _autoMapper.Map<Return.SchoolUser>(s);
            _tutorsLinkService.AddSelfLink(returnType);
            return returnType;
        }
    }
}

