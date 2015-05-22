using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.NewModels
{
    /// <summary>
    /// Clase usada para asociar un estudiante con un grupo
    /// </summary>
    public class NewEnrollment
    {
        /// <summary>
        /// El identificador del estudiante a añadir al grupo
        /// </summary>
        [Required]
        public int StudentId { get; set; }

        /// <summary>
        /// El identificador del grupo al que se añadirá el estudiante
        /// </summary>
        [Required]
        public int GroupId { get; set; }
    }
}
