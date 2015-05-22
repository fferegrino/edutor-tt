using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.NewModels
{
    /// <summary>
    /// Clase que representa un nuevo grupo en el sistema Edutor
    /// </summary>
    public class NewGroup 
    {
        /// <summary>
        /// El nombre del grupo
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// Una breve descripción del grupo
        /// </summary>
        [Required]
        [StringLength(35)]
        public string Subject { get; set; }

        /// <summary>
        /// La fecha en la que el grupo inicia
        /// </summary>
        [Required]
        [Range(typeof(DateTime), "1/2/2004", "3/4/2024")]
        public DateTime FromDate { get; set; }

        /// <summary>
        /// La fecha en la que el grupo expira
        /// </summary>
        [Range(typeof(DateTime), "1/2/2004", "3/4/2024")]
        public DateTime? ToDate { get; set; }
        
    }
}
