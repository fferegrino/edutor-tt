using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.ReturnTypes
{
    /// <summary>
    /// Representa una conversación, contiene información sobre los participantes 
    /// de la misma así como los mensajes recientes que tiene
    /// </summary>
    public class Conversation : LinkContaining
    {
        /// <summary>
        /// El identificador de la conversación
        /// </summary>
        public int ConversationId { get; set; }

        /// <summary>
        /// El identificador de uno de los usarios participantes de la conversación
        /// </summary>
        public int SenderId { get; set; }

        /// <summary>
        /// El nombre de uno de los usuarios participantes de la conversación
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        /// El identificador de uno de los usuarios participantes de la conversación
        /// </summary>
        public int RecipientId { get; set; }

        /// <summary>
        /// El nombre de uno de los usuarios participantes de la conversación
        /// </summary>
        public string RecipientName { get; set; }

        /// <summary>
        /// Una lista con los mensajes recientes al momento de consultar la conversación
        /// </summary>
        public IList<Message> LastMessages { get; set; }
    }
}
