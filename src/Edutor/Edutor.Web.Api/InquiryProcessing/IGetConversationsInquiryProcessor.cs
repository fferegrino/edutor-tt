﻿using Return = Edutor.Web.Api.Models.ReturnTypes;
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
using System.Web;
using Edutor.Common.Security;

namespace Edutor.Web.Api.InquiryProcessing
{
    public interface IGetConversationsInquiryProcessor
    {

        PagedDataResponse<Return.Conversation> GetMessagesForUser(int userId, PagedDataRequest request);

        Return.Message GetMessagesForConversation(int conversationId, int messageId);

        PagedDataResponse<Return.Message> GetMessagesForConversation(int conversationId, PagedDataRequest request);

        Return.Conversation GetConversation(int conversationId);
    }

    public class GetConversationsInquiryProcessor : IGetConversationsInquiryProcessor
    {

        private readonly IAutoMapper _autoMapper;
        private readonly IGetConversationsQueryProcessor _queryProcessor;
        private readonly IConversationsLinkService _linkServices;
        private readonly ICommonLinkService _commonLinkService;
        private readonly IWebUserSession _session;

        public GetConversationsInquiryProcessor(IAutoMapper autoMapper,
            IConversationsLinkService tutorsLinkService,
            IGetConversationsQueryProcessor queryProcessor,
            ICommonLinkService commonLinkService,
            IWebUserSession session)
        {
            _session = session;
            _autoMapper = autoMapper;
            _queryProcessor = queryProcessor;
            _commonLinkService = commonLinkService;
            _linkServices = tutorsLinkService;
        }

        public PagedDataResponse<Return.Message> GetMessagesForConversation(int conversationId, PagedDataRequest request)
        {
            var qresult = _queryProcessor.GetMessagesForConversation(conversationId, request);
            var returnUsers = GetCollection(qresult);
            var inquiryResponse = new PagedDataResponse<Return.Message>
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



        public PagedDataResponse<Return.Conversation> GetMessagesForUser(int userId, PagedDataRequest request)
        {
            var qresult = _queryProcessor.GetConversationForUser(userId, request);
            var returnUsers = MapConversations(qresult.QueriedItems.ToList());
            var inquiryResponse = new PagedDataResponse<Return.Conversation>
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
            string aux = null;
            int auxI = 0;
            int thisUser = _session.UserId;
            foreach (var msg in list)
            {
                var s = _autoMapper.Map<Return.Conversation>(msg);
                auxI = s.RecipientId;
                aux = s.RecipientName;
                if(s.SenderId != thisUser)
                {
                    s.RecipientName = s.SenderName;
                    s.RecipientId = s.SenderId;
                    s.SenderId = auxI;
                    s.SenderName = aux;
                }
                _linkServices.AddAllLinks(s);
                l.Add(s);
            }
            return l;
        }

    }
}

