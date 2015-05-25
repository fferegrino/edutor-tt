
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.ReturnTypes
{
    /// <summary>
    /// Clase que representa una pregunta dentro del sistema, contiene información de esta misma, como el texto de la pregunta y las posibles respeustas
    /// </summary>
    public class Question : LinkContaining
    {
        /// <summary>
        /// El identificador único del usuario escolar que creó la pregunta
        /// </summary>
        public int SchoolUserId { get; set; }


        /// <summary>
        /// El identificador único del grupo asociado con la notificación
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// El identificador único de la pregunta dentro del sistema
        /// </summary>
        public int QuestionId { get; set; }
        
        /// <summary>
        /// El texto de la pregunta realizada
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// La fecha en que la pregunta expira
        /// </summary>
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// Colección con respuestas posibles a la pregunta realizada
        /// </summary>
        public IList<PossibleAnswer> PossibleAnswers { get; set; }
        
    }
}
