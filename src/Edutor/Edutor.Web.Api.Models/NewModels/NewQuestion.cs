using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.NewModels
{
    /// <summary>
    /// Clase que representa una nueva pregunta en el sistema Edutor
    /// </summary>
    public class NewQuestion
    {
        /// <summary>
        /// El identificador del usuario escolar que genera la notificación
        /// </summary>
        [Required]
        public int SchoolUserId { get; set; }

        /// <summary>
        /// El identificador del grupo para el que se genera la pregunta
        /// </summary>
        [Required]
        public int GroupId { get; set; }

        /// <summary>
        /// El texto de la preginta
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Text { get; set; }

        /// <summary>
        /// La fecha en que la pregunta vence
        /// </summary>
        [Required]
        [Range(typeof(DateTime), "1/1/2004", "1/1/2024")]
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// Una lista de las respuestas posibles para esta pregunta
        /// </summary>
        [Required]
        public IList<string> PossibleAnswers { get; set; }
    }
}
