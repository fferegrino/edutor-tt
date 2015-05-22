using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.NewModels
{
    /// <summary>
    /// Clase que representa una notificación vista dentro del sistema Edutor
    /// </summary>
    public class NewSeenNotification
    {
        /// <summary>
        /// El identificador del usuario a nombre del que se marcará como vista la notificación
        /// </summary>
        [Required]
        public int StudentId { get; set; }

        /// <summary>
        /// El identificador de la notificación que se marcará como vista
        /// </summary>
        [Required]
        public int NotificationId { get; set; }

    }
}
