using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.NewModels
{
    public class NewUser 
    {
        /// <summary>
        /// El nombre del usuario
        /// </summary>
        [Required]
        [StringLength(70)]
        public string Name { get; set; }

        /// <summary>
        /// La Clave Única de Registro de Población del usuario
        /// </summary>
        [StringLength(18,MinimumLength=18)]
        [Required]
        public string Curp { get; set; }

        /// <summary>
        /// El correo electrónico del usuario
        /// </summary>
        [EmailAddress]
        [Required]
        [StringLength(60)]
        public string Email { get; set; }

        /// <summary>
        /// La dirección del usuario
        /// </summary>
        [Required]
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
