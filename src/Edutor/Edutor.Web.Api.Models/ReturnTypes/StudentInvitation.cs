﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.ReturnTypes
{
    /// <summary>
    /// Clase que representa la respuesta de un tutor a nombre de un estudiante a una invitación a un evento
    /// </summary>
    public class StudentInvitation : BasicStudent
    {
        /// <summary>
        /// El identificador único del evento dentro del sistema
        /// </summary>
        public int EventId { get; set; }


        /// <summary>
        /// El identificador único del grupo con el que está asociada la pregunta
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// El identificador único del usuario escolar dentro del sistema que generó la pregunta
        /// </summary>
        public int SchoolUserId { get; set; }

        /// <summary>
        /// El nombre del usuario escolar que generó el evento
        /// </summary>
        public string SchoolUserName { get; set; }

        /// <summary>
        /// El nombre del grupo con el que está asociado el evento
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// El nombre del evento
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// La fecha en la que se llevará a cabo el evento
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// La fecha en la que fue creado el evento
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Descripción breve del evento
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// La confirmación de asistencia al evento por parte del tutor
        /// </summary>
        public bool? Rsvp { get; set; }
    }
}
