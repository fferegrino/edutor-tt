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
    /// Los extremos de conversaciones permiten el intercambio de mensajes entre profesores y tutores.
    /// Las conversaciones son interacciones uno a uno, tutor con profesor.
    /// A diferencia de los otros tipos de interacciones en Edutor, las conversaciones no son únicas por alumno.
    /// </summary>
    [Edutor.Web.Common.UnitOfWorkActionFilter]
    public class ConversationsController : ApiController
    {
        private readonly IPostConversationsMaintenanceProcessor _postConversations;
        private readonly IGetConversationsInquiryProcessor _getConversations;
        private readonly IDeleteInteracionsMaintenanceProcessor _deleteConversations;
        private readonly IPagedDataRequestFactory _pagedFactory;
        public ConversationsController(IPostConversationsMaintenanceProcessor postConversations,
            IGetConversationsInquiryProcessor getConversations,
            IDeleteInteracionsMaintenanceProcessor deleteConversations,
            IPagedDataRequestFactory pagedFactory)
        {
            _postConversations = postConversations;
            _getConversations = getConversations;
            _pagedFactory = pagedFactory;
            _deleteConversations = deleteConversations;
        }

        /// <summary>
        /// Obtiene la conversación solicitada dado el identificador único, 
        /// un usuario administrador podrá recuperar cualquier conversación, 
        /// mientras que cualquier otro usuario solo podrá recuperar conversaciones de las que es participante.
        /// </summary>
        /// <param name="conversationId">El identificador la conversación a recuperar, debe ser un número mayor a 0.</param>
        /// <returns>Devuelve la conversación deseada, en caso de que exista y el usuario tenga permiso para acceder a ella.</returns>
        [Route("conversations/{conversationId:int}")]
        [HttpGet]
        [ResponseType(typeof(Conversation))]
        [Authorize(Roles = Constants.RoleNames.All)]
        public Conversation GetConversation(int conversationId)
        {
            return _getConversations.GetConversation(conversationId);
        }

        /// <summary>
        /// Obtiene una lista paginada que contiene los mensajes de la conversación solicitada, 
        /// un usuario administrador podrá recuperar los mensajes de cualquier conversación, 
        /// mientras que cualquier otro usuario solo podrá recuperar mensajes de conversaciones de las que es participante.
        /// </summary>
        /// <param name="conversationId">El identificador de la conversación a consultar</param>
        /// <returns>Una lista paginada con los mensajes de la conversación consultada, 
        /// en caso de que la conversación exista y el usuario tenga permiso para acceder a ella.</returns>
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
        /// Obtiene el mensaje solicitado de la conversación solicitada,
        /// un usuario administrador podrá recuperar los mensajes de cualquier conversación,
        /// mientras que cualquier otro usuario solo podrá recuperar mensajes de las conversaciones de las que es participante.
        /// </summary>
        /// <param name="conversationId">El identificador de la conversación a consultar.</param>
        /// /// <param name="messageId">El identificador del mensaje a consultar.</param>
        [Route("conversations/{conversationId:int}/messages/{messageId:int}")]
        [HttpGet]
        [ResponseType(typeof(Message))]
        [Authorize(Roles = Constants.RoleNames.All)]
        public Message GetMessageForConversation(int conversationId, int messageId)
        {
            return _getConversations.GetMessagesForConversation(conversationId, messageId);
        }

        /// <summary>
        /// Envía un nuevo mensaje y lo asocia a una conversación,
        /// en caso de que la conversación no exista, la crea.
        /// Un usuario administrador no podrá enviar mensajes.s
        /// </summary>
        /// <param name="message">El mensaje a a enviar a través del sistema.</param>
        /// <returns>El mensaje recién creado, con información sobre él mismo y la conversación a la que está asociado.</returns>
        [Route("conversations")]
        [HttpPost]
        [ResponseType(typeof(Message))]
        [Authorize(Roles = Constants.RoleNames.TeacherAndTutor)]
        public IHttpActionResult AddMessage(NewMessage message)
        {
            var x = _postConversations.AddNewMessage(message);
            var result = new ModelPostedActionResult<Message>(Request, x);
            return result;
        }

        /// <summary>
        /// Elimina la conversación del sistema, también los mensajes son eliminados
        /// Esta acción solamente puede ser llevada a cabo por administradores.
        /// </summary>
        /// <param name="conversationId"></param>
        /// <returns></returns>
        [Route("conversations/{conversationId:int}")]
        [HttpDelete]
        [Authorize(Roles = Constants.RoleNames.Administrator)]
        public IHttpActionResult DeleteConversations(int conversationId)
        {
            _deleteConversations.DeleteConversation(conversationId);
            return new ModelDeletedActionResult(Request);
        }
    }
}
