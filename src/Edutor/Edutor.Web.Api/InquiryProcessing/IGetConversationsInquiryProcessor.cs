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

        PagedDataInquiryResponse<Return.Conversation> GetMessagesForUser(int userId, PagedDataRequest request);

        Return.Message GetMessagesForConversation(int conversationId, int messageId);

        PagedDataInquiryResponse<Return.Message> GetMessagesForConversation(int conversationId, PagedDataRequest request);

        Return.Conversation GetConversation(int conversationId);
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

        public Return.Message GetMessagesForConversation(int conversationId, int messageId)
        {
            var ret = _queryProcessor.GetMessagesForConversation(conversationId, messageId);
            var s = _autoMapper.Map<Return.Message>(ret);
            _linkServices.AddAllLinks(s);

            return s;
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

        public Return.Conversation GetConversation(int conversationId)
        {
            var convo = _queryProcessor.GetConversation(conversationId);
            var ret = _autoMapper.Map<Return.Conversation>(convo);
            ret.LastMessages = MapMessages(_queryProcessor.GetLastMessagesForConversation(conversationId, 5));
            _linkServices.AddAllLinks(ret);
            return ret;
        }

        private IList<Return.Message> MapMessages(IList<Data.Entities.Message> list)
        {
            var l = new List<Return.Message>();
            foreach (var msg in list)
            {
                var s = _autoMapper.Map<Return.Message>(msg);
                _linkServices.AddAllLinks(s);
                l.Add(s);
            }
            return l;
        }



        public PagedDataInquiryResponse<Return.Conversation> GetMessagesForUser(int userId, PagedDataRequest request)
        {
            var qresult = _queryProcessor.GetConversationForUser(userId, request);
            var returnUsers = MapConversations(qresult.QueriedItems.ToList());
            var inquiryResponse = new PagedDataInquiryResponse<Return.Conversation>
            {
                Items = returnUsers,
                PageCount = qresult.TotalPageCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            _commonLinkService.AddPageLinks(inquiryResponse);

            return inquiryResponse;
        }

        private List<Return.Conversation> MapConversations(List<Data.Entities.Conversation> list)
        {
            var l = new List<Return.Conversation>();
            foreach (var msg in list)
            {
                var s = _autoMapper.Map<Return.Conversation>(msg);
                _linkServices.AddAllLinks(s);
                l.Add(s);
            }
            return l;
        }

    }
}

