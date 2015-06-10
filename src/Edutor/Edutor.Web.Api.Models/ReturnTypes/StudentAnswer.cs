
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.ReturnTypes
{
    /// <summary>
    /// Clase que representa la respuesta de un tutor a nombre de un estudiante a una pregunta
    /// </summary>
    public class StudentAnswer : BasicStudent
    {
        /// <summary>
        /// El identificador único del usuario escolar dentro del sistema que generó la pregunta
        /// </summary>
        public int SchoolUserId { get; set; }


        /// <summary>
        /// El identificador único de la pregunta dentro del sistema
        /// </summary>
        public int QuestionId { get; set; }

        /// <summary>
        /// El identificador único del grupo con el que está asociada la pregunta
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// El nombre del usuario escolar que generó la pregunta
        /// </summary>
        public string SchoolUserName { get; set; }

        /// <summary>
        /// El nombre del grupo con el que está asociada la pregunta
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// El texto de la pregunta
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// El identificador de la respuesta elegida por el tutor
        /// </summary>
        public int AnswerId { get; set; }

        /// <summary>
        /// El texto de la respuesta elegida por el tutor
        /// </summary>
        public string AnswerText { get; set; }

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
