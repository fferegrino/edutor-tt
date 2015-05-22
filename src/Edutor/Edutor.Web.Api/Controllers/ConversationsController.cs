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
    /// <summary>
    /// Conjunto de extremos REST que permiten operar con los servicios de mensajería que ofrece la plataforma
    /// </summary>
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

        /// <summary>
        /// Obtiene los mensajes de una conversación
        /// </summary>
        /// <param name="conversationId">El id de la conversación a consultar</param>
        /// <returns>Una lista paginada con los mensajes de la conversación consultada</returns>
        [HttpGet]
        [Route("conversations/{conversationId:int}/messages")]
        [ResponseType(typeof(PagedDataInquiryResponse<Message>))]
        public PagedDataInquiryResponse<Message> GetMessagesForConversation(int conversationId)
        {
            var r = _getConversations.GetMessagesForConversation(conversationId, _pagedFactory.Create(Request.RequestUri));
            return r;
        }

        /// <summary>
        /// Obtiene el mensaje indicado de la conversación deseada
        /// </summary>
        /// <param name="conversationId">El id de la conversación a consultar</param>
        /// /// <param name="messageId">El id del mensaje a consultar</param>
        [HttpGet]
        [Route("conversations/{conversationId:int}/messages/{messageId:int}")]
        [ResponseType(typeof(Message))]
        public Message GetMessagesForConversation(int conversationId, int messageId)
        {
            return _getConversations.GetMessagesForConversation(conversationId, messageId);
        }

        /// <summary>
        /// Obtiene la conversación indicada
        /// </summary>
        /// <param name="conversationId">El id de la conversación a recuperar</param>
        /// <returns></returns>
        [HttpGet]
        [Route("conversations/{conversationId:int}")]
        [ResponseType(typeof(Conversation))]
        public Conversation GetConversation(int conversationId)
        {
            return _getConversations.GetConversation(conversationId);
        }
    }
}
