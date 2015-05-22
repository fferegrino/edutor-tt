using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.NewModels
{
    /// <summary>
    /// Clase que representa un nuevo mensaje en el sistema Edutor
    /// </summary>
    public class NewMessage 
    {
        /// <summary>
        /// El identificador del receptor del mensaje
        /// </summary>
        [Required]
        public int ToId { get; set; }

        /// <summary>
        /// El identificador de quien envía el mensaje
        /// </summary>
        [Required]
        public int FromId { get; set; }

        /// <summary>
        /// El contenido del mensaje
        /// </summary>
        [Required]
        [StringLength(400)]
        public string Text { get; set; }
    }
}
