using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.NewModels
{
    /// <summary>
    /// Clase que representa un nuevo evento en el sistema Edutor
    /// </summary>
    public class NewEvent
    {
        /// <summary>
        /// El identificador del usuario escolar que genera el evento
        /// </summary>
        [Required]
        public int SchoolUserId { get; set; }

        /// <summary>
        /// El grupo para el que se genera el evento
        /// </summary>
        [Required]
        public int GroupId { get; set; }

        /// <summary>
        /// El nombre del evento
        /// </summary>
        [Required]
        [StringLength(60)]
        public string Name { get; set; }

        /// <summary>
        /// La fecha en la que el evento se llevará a cabo
        /// </summary>
        [Required]
        [Range(typeof(DateTime), "1/2/2004", "3/4/2024")]
        public DateTime Date { get; set; }

        /// <summary>
        /// La descripción del evento
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
    }
}
