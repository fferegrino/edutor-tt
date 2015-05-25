using Edutor.Common;
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
        /// Obtiene la conversación indicada
        /// </summary>
        /// <param name="conversationId">El id de la conversación a recuperar</param>
        /// <returns>Responde con la conversación indicada, en caso de que no exista se responderá con un código de error</returns>
        [Route("conversations/{conversationId:int}")]
        [HttpGet]
        [ResponseType(typeof(Conversation))]
        [Authorize(Roles = Constants.RoleNames.All)]
        public Conversation GetConversation(int conversationId)
        {
            return _getConversations.GetConversation(conversationId);
        }

        /// <summary>
        /// Regresa una lista paginada con los mensajes de la conversación indicada
        /// </summary>
        /// <param name="conversationId">El id de la conversación a consultar</param>
        /// <returns>Una lista paginada con los mensajes de la conversación consultada</returns>
        [Route("conversations/{conversationId:int}/messages")]
        [HttpGet]
        [ResponseType(typeof(PagedDataResponse<Message>))]
        [Authorize(Roles = Constants.RoleNames.All)]
        public PagedDataResponse<Message> GetMessagesForConversation(int conversationId)
        {
            var r = _getConversations.GetMessagesForConversation(conversationId, _pagedFactory.Create(Request.RequestUri));
            return r;
        }

        /// <summary>
        /// Obtiene el mensaje indicado de la conversación deseada
        /// </summary>
        /// <param name="conversationId">El id de la conversación a consultar</param>
        /// /// <param name="messageId">El id del mensaje a consultar</param>
        [Route("conversations/{conversationId:int}/messages/{messageId:int}")]
        [HttpGet]
        [ResponseType(typeof(Message))]
        [Authorize(Roles = Constants.RoleNames.All)]
        public Message GetMessagesForConversation(int conversationId, int messageId)
        {
            return _getConversations.GetMessagesForConversation(conversationId, messageId);
        }

        /// <summary>
        /// Envía un nuevo mensaje y se asocia con una conversación, en caso de no existir, se crea una conversación
        /// </summary>
        /// <param name="message">El mensaje a a enviar a través del sistema</param>
        /// <returns></returns>
        [Route("conversations")]
        [HttpPost]
        [ResponseType(typeof(Message))]
        [Authorize(Roles = Constants.RoleNames.All)]
        public IHttpActionResult AddTutor(NewMessage message)
        {
            var x = _postConversations.AddNewMessage(message);
            var result = new ModelPostedActionResult<Message>(Request, x);
            return result;
        }
    }
}
