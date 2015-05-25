using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edutor.Web.Api.Models.ReturnTypes
{
    /// <summary>
    /// Clase que representa una respeusta posible a una pregunta realizada dentro de edutor
    /// </summary>
    public class PossibleAnswer : LinkContaining
    {
        /// <summary>
        /// El identificador único de la pregunta con la que esta respuesta está asociada
        /// </summary>
        public int QuestionId { get; set; }

        /// <summary>
        /// Un identificador para esta respuesta posible
        /// </summary>
        public int PossibleAnswerId { get; set; }

        /// <summary>
        /// El texto de la respuesta
        /// </summary>
        public string Text { get; set; }
    }
}
