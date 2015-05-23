using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.ModModels
{
    public class ModifiableStudent
    {
        /// <summary>
        /// El identificador del estudiante a modificar
        /// </summary>
        [Required]
        public int StudentId { get; set; }


        ///// <summary>
        ///// El tutor asignado a este estudiante
        ///// </summary>
        //public int? TutorId { get; set; }

        /// <summary>
        /// La relación entre el tutor y el estudiante
        /// </summary>
        [StringLength(3, MinimumLength = 3)]
        public string TutorRelationship { get; set; }

        /// <summary>
        /// Dirección del estudiante
        /// </summary>
        [StringLength(512)]
        public string Address { get; set; }

        /// <summary>
        /// Teléfono de la casa del estudiante
        /// </summary>
        [StringLength(10)]
        public string Phone { get; set; }

        /// <summary>
        /// El nombre del estudiante
        /// </summary>
        [StringLength(60)]
        public string Name { get; set; }
    }
}
