using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Edutor.Web.Api.Models.NewModels
{
    /// <summary>
    /// Clase que representa un nuevo usuario escolar dentro del sistema Edutor
    /// </summary>
    public class NewSchoolUser : NewUser
    {
        /// <summary>
        /// La posición que ocupa el usuario escolar dentro de la escuela: <code>A</code> para administrador, <code>P</code> para profesor
        /// </summary>
        [Required]
        public char Position { get; set; }
    }
}
