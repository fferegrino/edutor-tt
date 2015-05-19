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
    public interface IGetConversationsInquiryProcessor
    {

        //PagedDataInquiryResponse<Return.Group> GetAllGroups(PagedDataRequest request);

        PagedDataInquiryResponse<Return.Message> GetMessagesForConversation(int conversationId, PagedDataRequest request);
        //Return.Conversation GetConversation(int groupId);
    }

    public class GetConversationsInquiryProcessor : IGetConversationsInquiryProcessor
    {

        private readonly IAutoMapper _autoMapper;
        private readonly IGetConversationsQueryProcessor _queryProcessor;
        private readonly IConversationsLinkService _linkServices;
        private readonly ICommonLinkService _commonLinkService;

        public GetConversationsInquiryProcessor(IAutoMapper autoMapper,
            IConversationsLinkService tutorsLinkService,
            IGetConversationsQueryProcessor queryProcessor,
            ICommonLinkService commonLinkService)
        {
            _autoMapper = autoMapper;
            _queryProcessor = queryProcessor;
            _commonLinkService = commonLinkService;
            _linkServices = tutorsLinkService;
        }

        public PagedDataInquiryResponse<Return.Message> GetMessagesForConversation(int conversationId, PagedDataRequest request)
        {
            var qresult = _queryProcessor.GetMessagesForConversation(conversationId, request);
            var returnUsers = GetCollection(qresult);
            var inquiryResponse = new PagedDataInquiryResponse<Return.Message>
            {
                Items = returnUsers,
                PageCount = qresult.TotalPageCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            _commonLinkService.AddPageLinks(inquiryResponse);

            return inquiryResponse;
        }


        private List<Return.Message> GetCollection(QueryResult<Data.Entities.Message> qresult)
        {
            var x = qresult.QueriedItems.Select(r => _autoMapper.Map<Return.Message>(r)).ToList();
            x.ForEach(t => _linkServices.AddAllLinks(t));
            return x;
        }
        
        public Return.Message GetMessage(int conversationId, int messageId)
        {
            var s = _queryProcessor.GetMessagesForConversation(conversationId, messageId);
            var returnType = _autoMapper.Map<Return.Message>(s);
            _linkServices.AddAllLinks(returnType);
            return returnType;
        }


    }
}

