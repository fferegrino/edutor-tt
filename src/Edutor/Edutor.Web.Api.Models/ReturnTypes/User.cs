using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.ReturnTypes
{
    public class User : LinkContaining
    {
        /// <summary>
        /// Identificador único del usuario dentro del sistema
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// La Clave Única de Registro de Población del usuario
        /// </summary>
        public string Curp { get; set; }

        /// <summary>
        /// El correo electrónico del usuario
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// La dirección física del estudiante
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Numero telefónico móvil del usuario
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// Número telefónico fijo del usuario
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Tipo de usuario, 'T' para tutor, 'S' para usuario escolar
        /// </summary>
        public char Type { get; set; }
    }
}
