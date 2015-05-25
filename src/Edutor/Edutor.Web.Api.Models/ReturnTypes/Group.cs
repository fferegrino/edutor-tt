using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.ReturnTypes
{
    /// <summary>
    /// Clase que representa un grupo escolar, tiene información como el nombre y la materia del grupo
    /// </summary>
    public class Group : LinkContaining
    {
        /// <summary>
        /// El identificador único del grupo dentro del sistema
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// El nomrbe del grupo
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Una descripción o la materia del grupo
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Desde ´qué fecha está este grupo activo
        /// </summary>
        public DateTime FromDate { get; set; }

        /// <summary>
        /// Hasta qué fecha está este grupo activo
        /// </summary>
        public DateTime? ToDate { get; set; }

        /// <summary>
        /// Conteo de los estudiantes con los que cuenta el grupo
        /// </summary>
        public int StudentsCount { get; set; }

        /// <summary>
        /// Conteo de los profesores con los que cuenta el grupo
        /// </summary>
        public int TeachersCount { get; set; }
    }
}
