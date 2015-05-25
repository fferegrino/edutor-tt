using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.ReturnTypes
{
    public class BasicStudent : LinkContaining
    {
        /// <summary>
        /// El identificador único del estudiante dentro del sistema
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// La Clave Única de Registro de Población del estudiante
        /// </summary>
        public string Curp { get; set; }

        /// <summary>
        /// El nombre real del estudiante
        /// </summary>
        public string Name { get; set; }
        //public string Token { get; set; }

    }
}
