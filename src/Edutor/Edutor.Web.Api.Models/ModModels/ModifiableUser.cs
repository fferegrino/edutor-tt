using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.ModModels
{
    public class ModifiableUser
    {
        /// <summary>
        /// El identificador del usuario dentro del sistema
        /// </summary>
        [Required]  
        public int UserId { get; set; }

        /// <summary>
        /// El nombre del usuario
        /// </summary>
        [StringLength(70)]
        public string Name { get; set; }

        /// <summary>
        /// El correo electrónico del usuario
        /// </summary>
        [EmailAddress]
        [StringLength(60)]
        public string Email { get; set; }

        /// <summary>
        /// La dirección del usuario
        /// </summary>
        [StringLength(512)]
        public string Address { get; set; }

        /// <summary>
        /// Número de teléfono móvil del usuario
        /// </summary>
        [StringLength(10)]
        public string Mobile { get; set; }

        /// <summary>
        /// Número de teléfono del usuario
        /// </summary>
        [StringLength(10)]
        public string Phone { get; set; }
    }
}
