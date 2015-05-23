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
    public interface IGetNotificationsInquiryProcessor
    {

        PagedDataResponse<Return.Notification> GetNotificationsForSchoolUser(int schoolUserId, PagedDataRequest request);

        PagedDataResponse<Return.Notification> GetNotificationsForStudent(int studentId, PagedDataRequest requestInfo);

        Return.Notification GetNotification(int notificationId);
    }

    public class GetNotificationsInquiryProcessor : IGetNotificationsInquiryProcessor
    {

        private readonly IAutoMapper _autoMapper;
        private readonly IGetNotificationsQueryProcessor _queryProcessor;
        private readonly INotificationsLinkService _notifLinkService;
        private readonly ICommonLinkService _commonLinkService;

        public GetNotificationsInquiryProcessor(IAutoMapper autoMapper,
            IGetNotificationsQueryProcessor queryProcessor,
            INotificationsLinkService notifLinkService,
            ICommonLinkService commonLinkService)
        {
            _autoMapper = autoMapper;
            _queryProcessor = queryProcessor;
            _notifLinkService = notifLinkService;
            _commonLinkService = commonLinkService;
        }

        public Models.PagedDataResponse<Return.Notification> GetNotificationsForSchoolUser(int schoolUserId, PagedDataRequest request)
        {
            var qresult = _queryProcessor.GetNotificationsForSchoolUser(schoolUserId, request);

            var inquiryResponse = new PagedDataResponse<Return.Notification>
            {
                Items = CastCollection(qresult),
                PageCount = qresult.TotalPageCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            _commonLinkService.AddPageLinks(inquiryResponse);

            return inquiryResponse;
        }

        public PagedDataResponse<Return.Notification> GetNotificationsForStudent(int studentId, PagedDataRequest request)
        {
            var qresult = _queryProcessor.GetNotificationsForStudent(studentId, request);

            var inquiryResponse = new PagedDataResponse<Return.Notification>
            {
                Items = CastCollection(qresult),
                PageCount = qresult.TotalPageCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            _commonLinkService.AddPageLinks(inquiryResponse);

            return inquiryResponse;
        }

        private List<Return.Notification> CastCollection(QueryResult<Data.Entities.Notification> qresult)
        {
            var x = qresult.QueriedItems.Select(r => _autoMapper.Map<Return.Notification>(r)).ToList();
            x.ForEach(t => _notifLinkService.AddAllLinks(t));
            return x;
        }

        public Return.Notification GetNotification(int id)
        {
            var r = _queryProcessor.GetNotification(id);
            var t = _autoMapper.Map<Return.Notification>(r);
            _notifLinkService.AddAllLinks(t);
            return t;
        }




    }
}
