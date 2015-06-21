using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.ReturnTypes
{
    /// <summary>
    /// Clase que representa una notificación
    /// </summary>
    public class Notification : LinkContaining
    {
        /// <summary>
        /// El identificador único de la notificación dentro del sistema
        /// </summary>
        public int NotificationId { get; set; }

        /// <summary>
        /// El identificador único del usuario escolar que generó la notificación
        /// </summary>
        public int SchoolUserId { get; set; }

        /// <summary>
        /// El identificador único del grupo asociado con la notificación
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// El contenido de la notificación
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// La cantidad de estudiantes notificados
        /// </summary>
        public int TotalStudents { get; set; }


        /// <summary>
        /// La cantidad de estudiantes que han revisado la notificación
        /// </summary>
        public int SeenStudents { get; set; }
    }
}
