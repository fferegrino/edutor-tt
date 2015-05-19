using Edutor.Common;
using Edutor.Common.TypeMapping;
using Edutor.Data.QueryProcessors;
using Edutor.Web.Api.LinkServices;
using Edutor.Web.Api.Models;
using Edutor.Web.Api.Models.NewModels;
using Edutor.Web.Api.Models.ReturnTypes;
using Entity = Edutor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.MaintenanceProcessing
{
    public interface IPostConversationsMaintenanceProcessor
    {
        Message AddNewMessage(NewMessage newMessage);
    }

    public class PostConversationsMaintenanceProcessor : IPostConversationsMaintenanceProcessor
    {

        private readonly IAutoMapper _mapper;
        private readonly IAddConversationQueryProcessor _addConversation;
        private readonly IConversationsLinkService _conversationsLinkService;

        public PostConversationsMaintenanceProcessor(IAutoMapper autoMapper, 
            IAddConversationQueryProcessor addUserQueryProcessor,
            IConversationsLinkService conversationsLinkService)
        {
            _mapper = autoMapper;
            _addConversation = addUserQueryProcessor;
            _conversationsLinkService = conversationsLinkService;
        }

        public Message AddNewMessage(NewMessage newMessage)
        {
            var msg = _mapper.Map<Entity.Message>(newMessage);
            _addConversation.AddNewMessage(msg);
            var rt = _mapper.Map<Message>(msg);
            _conversationsLinkService.AddAllLinks(rt);
            return rt;
        }
    }
}

