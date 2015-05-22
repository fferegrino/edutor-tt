using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.NewModels
{
    /// <summary>
    /// Clase que representa una nueva notificación en el sistema Edutor
    /// </summary>
    public class NewNotification
    {
        /// <summary>
        /// El identificador del usuario escolar que genera la notificación
        /// </summary>
        [Required]
        public int SchoolUserId { get; set; }

        /// <summary>
        /// El identificador del grupo para el que se genera la notificación
        /// </summary>
        [Required]
        public int GroupId { get; set; }

        /// <summary>
        /// El texto de la notificación
        /// </summary>
        [Required]
        [StringLength(300)]
        public string Text { get; set; }
    }
}
