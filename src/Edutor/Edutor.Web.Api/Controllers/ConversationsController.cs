using Edutor.Web.Api.InquiryProcessing;
using Edutor.Web.Api.MaintenanceProcessing;
using Edutor.Web.Api.Models;
using Edutor.Web.Api.Models.NewModels;
using Edutor.Web.Api.Models.ReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Edutor.Web.Api.Controllers
{
    [Edutor.Web.Common.UnitOfWorkActionFilter]
    public class ConversationsController : ApiController
    {
        private readonly IPostConversationsMaintenanceProcessor _postConversations;
        private readonly IGetConversationsInquiryProcessor _getConversations;
        private readonly IPagedDataRequestFactory _pagedFactory;
        public ConversationsController(IPostConversationsMaintenanceProcessor postConversations,
            IGetConversationsInquiryProcessor getConversations,
            IPagedDataRequestFactory pagedFactory)
        {
            _postConversations = postConversations;
            _getConversations = getConversations;
            _pagedFactory = pagedFactory;
        }

        [Route("conversations/{conversationId:int}/messages")]
        [ResponseType(typeof(PagedDataInquiryResponse<Message>))]
        public PagedDataInquiryResponse<Message> GetMessagesForConversation(int conversationId)
        {
            var r = _getConversations.GetMessagesForConversation(conversationId, _pagedFactory.Create(Request.RequestUri));
            return r;
        }

        /// <summary>
        /// Envía un nuevo mensaje, en caso de no existir, se crea una conversación
        /// </summary>
        /// <param name="newTutor">El nuevo tutor a ingresar</param>
        /// <returns></returns>
        [HttpPost]
        [Route("conversations")]
        [ResponseType(typeof(Message))]
        public IHttpActionResult AddTutor(NewMessage newMessage)
        {
            //var user = _addUserQueryProcessor.AddUser(newTutor);
            var x = _postConversations.AddNewMessage(newMessage);
            var result = new ModelPostedActionResult<Message>(Request, x);
            return result;
        }
    }
}
