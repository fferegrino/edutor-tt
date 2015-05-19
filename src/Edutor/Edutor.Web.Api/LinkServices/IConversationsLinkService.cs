using Edutor.Common;
using Edutor.Web.Api.Models;
using Edutor.Web.Api.Models.NewModels;
using Edutor.Web.Api.Models.ReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.LinkServices
{
    public interface IConversationsLinkService
    {
        void AddAllLinks(Message msg);
        void AddAllLinks(Conversation msg);
    }

    public class ConversationsLinkService : IConversationsLinkService
    {
        private readonly ICommonLinkService _commonLinkService;

        public ConversationsLinkService(ICommonLinkService commonLinkService)
        {
            _commonLinkService = commonLinkService;
        }

        public void AddAllLinks(Message msg)
        {
            var studentAnswerLinks = String.Format("conversations/{0}/messages/{1}", msg.ConversationId, msg.MessageId);
            msg.AddLink(_commonLinkService.GetLink(studentAnswerLinks, Constants.CommonLinkRelValues.Self, HttpMethod.Get));

            msg.AddLink(_commonLinkService.GetLink(String.Format("conversations/{0}", msg.ConversationId), Constants.CommonLinkRelValues.ConversationRel, HttpMethod.Get));
        }


        public void AddAllLinks(Conversation msg)
        {
            var studentAnswerLinks = String.Format("conversations/{0}", msg.ConversationId);
            msg.AddLink(_commonLinkService.GetLink(studentAnswerLinks, Constants.CommonLinkRelValues.Self, HttpMethod.Get));
            msg.AddLink(_commonLinkService.GetLink(studentAnswerLinks + "/messages", Constants.CommonLinkRelValues.MessagesRel, HttpMethod.Get));
        }
    }
}