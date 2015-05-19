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
            var studentAnswerLinks = String.Format("conversation/{0}/message/{1}", msg.ConversationId, msg.MessageId);
            msg.AddLink(_commonLinkService.GetLink(studentAnswerLinks, Constants.CommonLinkRelValues.Self, HttpMethod.Get));
        }
    }
}