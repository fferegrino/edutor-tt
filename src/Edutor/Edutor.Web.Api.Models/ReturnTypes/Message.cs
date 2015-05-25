using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.ReturnTypes
{
    /// <summary>
    /// Clase que representa un mensaje, contiene información de los participantes y de las fechas en que fue enviado y visto el mensaje
    /// </summary>
    public class Message : LinkContaining
    {
        /// <summary>
        /// El identificador único de la conversación a la que pertenece el mensaje dentro del sistema
        /// </summary>
        public int ConversationId { get; set; }

        /// <summary>
        /// El identificador único del mensaje dentro del sistema
        /// </summary>
        public int MessageId { get; set; }

        /// <summary>
        /// El identificador único del usuario al que fue enviado el mensaje
        /// </summary>
        public int ToId { get; set; }

        /// <summary>
        /// El identificador único del usuario que envió el mensaje
        /// </summary>
        public int FromId { get; set; }

        /// <summary>
        /// El contenido del mensaje
        /// </summary>
        public string Text { get; set; }


        /// <summary>
        /// La fecha en que el mensaje fue enviado por el emisor
        /// </summary>
        public DateTime SentDate { get; set; }

        /// <summary>
        /// La fecha en que el receptor vio el mensaje
        /// </summary>
        public DateTime? SeenDate { get; set; }
    }
}
