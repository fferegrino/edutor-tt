using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.NewModels
{
    /// <summary>
    /// Clase que representa una nueva respuesta en el sistema Edutor
    /// </summary>
    public class NewAnswer
    {
        /// <summary>
        /// El identificador de la respuesta elegida
        /// </summary>
        [Required]
        public int SelectedAnswerId { get; set; }

        /// <summary>
        /// El identificador del estudiante a nombre del que se responde
        /// </summary>
        [Required]
        public int StudentId { get; set; }

        /// <summary>
        /// El identificador de la pregunta que se responde
        /// </summary>
        [Required]
        public int QuestionId { get; set; }

    }
}
