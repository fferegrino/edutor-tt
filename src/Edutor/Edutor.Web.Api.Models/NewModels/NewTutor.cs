using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.NewModels
{
    /// <summary>
    /// Clase que representa un nuevo tutor dentro del sistema Edutor
    /// </summary>
    public class NewTutor : NewUser
    {
        /// <summary>
        /// El trabajo del tutor
        /// </summary>
        [StringLength(20)]
        public string Job { get; set; }

        /// <summary>
        /// El teléfono del trabajo del tutor
        /// </summary>
        [StringLength(10)]
        public string JobTelephone { get; set; }
    }
}
