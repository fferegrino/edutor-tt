using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.ReturnTypes
{
    /// <summary>
    /// Clase que representa un estudiante dentro del sistema
    /// </summary>
    public class Student : LinkContaining
    {
        /// <summary>
        /// El identificador único del estudiante dentro del sistema
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// El identificador único del tutor del estudiante dentro del sistema
        /// </summary>
        public int TutorId { get; set; }

        /// <summary>
        /// Una cadena de tres caracteres que describe la relación existente entre el estudiante y su tutor
        /// </summary>
        public string TutorRelationship { get; set; }

        /// <summary>
        /// Un valor que indica si es que el estudiante ha sido activado o no por su tutor
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// La dirección física del estudiante
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// El teléfono registrado para el estudiante
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// La Clave Única de Registro de Población
        /// </summary>
        public string Curp { get; set; }

        /// <summary>
        /// El nombre del estudiante
        /// </summary>
        public string Name { get; set; }

    }
}
