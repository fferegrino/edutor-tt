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
    public interface IGetTutorsInquiryProcessor
    {

        PagedDataResponse<Return.Tutor> GetAllTutors(PagedDataRequest request);

        Return.Tutor GetTutor(int id);

        Return.Tutor GetTutor(string curp);
    }

    public class GetTutorsInquiryProcessor : IGetTutorsInquiryProcessor
    {

        private readonly IAutoMapper _autoMapper;
        private readonly IGetUsersQueryProcessor _queryProcessor;
        private readonly ITutorsLinkService _tutorsLinkService;
        private readonly ICommonLinkService _commonLinkService;
        public GetTutorsInquiryProcessor(IAutoMapper autoMapper,
            IGetUsersQueryProcessor queryProcessor,
            ICommonLinkService commonLinkService,
            ITutorsLinkService tutorsLinkService)
        {
            _autoMapper = autoMapper;
            _queryProcessor = queryProcessor;
            _commonLinkService = commonLinkService;
            _tutorsLinkService = tutorsLinkService;
        }

        public PagedDataResponse<Return.Tutor> GetAllTutors(PagedDataRequest request)
        {
            var qresult = _queryProcessor.GetTutors(request);
            var returnUsers = GetTutors(qresult);
            var inquiryResponse = new PagedDataResponse<Return.Tutor>
            {
                Items = returnUsers,
                PageCount = qresult.TotalPageCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            _commonLinkService.AddPageLinks(inquiryResponse);

            return inquiryResponse;
        }

        private List<Return.Tutor> GetTutors(QueryResult<Data.Entities.User> qresult)
        {
            var x = qresult.QueriedItems.Select(r => _autoMapper.Map<Return.Tutor>(r)).ToList();
            x.ForEach(t => _tutorsLinkService.AddAllLinks(t));
            return x;
        }

        public Return.Tutor GetTutor(int id) {
            var t = _autoMapper.Map<Return.Tutor>(_queryProcessor.GetTutor(id));
            _tutorsLinkService.AddAllLinks(t);
            return t;
        }

        public Return.Tutor GetTutor(string curp)
        {
            var t = _autoMapper.Map<Return.Tutor>(_queryProcessor.GetTutor(curp));
            _tutorsLinkService.AddAllLinks(t);
            return t;
        }

    }
}
