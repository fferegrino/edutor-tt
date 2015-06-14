using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.ReturnTypes
{
    /// <summary>
    /// Clase que repressenta un evento, contiene información escencial de este como su nombre y al fecha en que se llevará a cabo
    /// </summary>
    public class Event : LinkContaining
    {
        /// <summary>
        /// El identificador único del evento dentro del sistema
        /// </summary>
        public int EventId { get; set; }

        /// <summary>
        /// El identificador del grupo con el que el evento está asociado
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// El identificador único del usuario que creó el evento
        /// </summary>
        public int SchoolUserId { get; set; }

        /// <summary>
        /// El nombre del evento
        /// </summary>
        public string Name { get; set; }

       /// <summary>
       /// La fecha en la que se llevará a cabo el evento
       /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// La fecha en la que fue creado el evento
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Una breve descripción de lo que tratará el evento
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Número de estudiantes con asistencia confirmada
        /// </summary>
        public int AttendeesComing { get; set; }

        /// <summary>
        /// Número de estudiantes que han negado su asistencia
        /// </summary>
        public int AttendeesNotComing { get; set; }

        /// <summary>
        /// Número de estudiantes que no han respondido
        /// </summary>
        public int AttendeesNoAnswer { get; set; }
    }
}
