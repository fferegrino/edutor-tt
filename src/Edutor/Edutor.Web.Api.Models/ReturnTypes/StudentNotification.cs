using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.ReturnTypes
{
    /// <summary>
    /// Clase que representa un detale de notificación para tutores dentro del sistema
    /// </summary>
    public class StudentNotification : BasicStudent
    {
        /// <summary>
        /// El identificador único de la notificación dentro del sistema
        /// </summary>
        public int NotificationId { get; set; }

        /// <summary>
        /// El identificador único del usuario escolar dentro del sistema que generó la pregunta
        /// </summary>
        public int SchoolUserId { get; set; }

        /// <summary>
        /// El identificador único del grupo con el que está asociada la pregunta
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// El nombre del usuario escolar que generó la notificación
        /// </summary>
        public string SchoolUserName { get; set; }

        /// <summary>
        /// El nombre del grupo con el que está asociada la notificación
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// El texto de la notificación
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Valor que indica si la notificación ha sido vista por el receptor
        /// </summary>
        public bool Seen { get; set; }
    }
}
