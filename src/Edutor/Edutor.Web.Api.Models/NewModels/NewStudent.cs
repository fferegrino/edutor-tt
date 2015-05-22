using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.NewModels
{
    /// <summary>
    /// Clase que representa un nuevo estudiante en el sistema Edutor
    /// </summary>
    public class NewStudent
    {
        /// <summary>
        /// El tutor asignado a este estudiante
        /// </summary>
        [Required]
        public int TutorId { get; set; }

        /// <summary>
        /// La relación entre el tutor y el estudiante
        /// </summary>
        [StringLength(3)]
        public string TutorRelationship { get; set; }

        /// <summary>
        /// Dirección del estudiante
        /// </summary>
        [Required]
        [StringLength(512)]
        public string Address { get; set; }

        /// <summary>
        /// Teléfono de la casa del estudiante
        /// </summary>
        [StringLength(10)]
        public string Phone { get; set; }

        /// <summary>
        /// La Clave Única de Registro de Población del estudiante
        /// </summary>
        [Required]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "La CURP consta de 18 caracteres")]
        public string Curp { get; set; }

        /// <summary>
        /// El nombre del estudiante
        /// </summary>
        [Required]
        [StringLength(60)]
        public string Name { get; set; }

    }
}
