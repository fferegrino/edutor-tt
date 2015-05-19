using Edutor.Common;
using Edutor.Common.TypeMapping;
using Edutor.Data.QueryProcessors;
using Edutor.Web.Api.LinkServices;
using Edutor.Web.Api.Models;
using Edutor.Web.Api.Models.NewModels;
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
    }

    public class PostConversationsMaintenanceProcessor : IPostConversationsMaintenanceProcessor
    {

        private readonly IAutoMapper _autoMapper;
        private readonly IAddConversationQueryProcessor _addConversation;

        public PostConversationsMaintenanceProcessor(IAutoMapper autoMapper, 
            IAddConversationQueryProcessor addUserQueryProcessor)
        {
            _autoMapper = autoMapper;
            _addConversation = addUserQueryProcessor;
        }

    }
}
