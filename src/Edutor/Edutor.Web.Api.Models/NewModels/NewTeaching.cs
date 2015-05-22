using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Edutor.Web.Api.Models.NewModels
{
    /// <summary>
    /// Clase usada para asociar un usuario escolar con un grupo
    /// </summary>
    public class NewTeaching
    {
        /// <summary>
        /// El identificador del usuario escolar que se asociará con el grupo
        /// </summary>
        [Required]
        public int SchoolUserId { get; set; }

        /// <summary>
        /// El identificador del grupo al que se añadirá el estudiante
        /// </summary>
        [Required]
        public int GroupId { get; set; }
    }
}
