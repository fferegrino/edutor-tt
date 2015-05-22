using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.NewModels
{
    /// <summary>
    /// Clase que representa un la respuesta a un evento en el sistema Edutor
    /// </summary>
    public class NewRsvp
    {
        /// <summary>
        /// La respuesta al evento
        /// </summary>
        [Required]
        public bool Rsvp { get; set; }

        /// <summary>
        /// El identificador del estudiante a nombre del cual se responde al evento
        /// </summary>
        [Required]
        public int StudentId { get; set; }

        /// <summary>
        /// El identificador del evento al que se responde
        /// </summary>
        [Required]
        public int EventId { get; set; }

    }
}
