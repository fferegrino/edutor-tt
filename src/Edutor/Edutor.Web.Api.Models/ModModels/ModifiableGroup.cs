using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.ModModels
{
    public class ModifiableGroup
    {
        public int GroupId { get; set; }

        /// <summary>
        /// El nombre del grupo
        /// </summary>
        [StringLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// Una breve descripción del grupo
        /// </summary>
        [StringLength(35)]
        public string Subject { get; set; }

        /// <summary>
        /// La fecha en la que el grupo inicia
        /// </summary>
        [Range(typeof(DateTime), "1/2/2004", "3/4/2024")]
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// La fecha en la que el grupo inicia
        /// </summary>
        [Range(typeof(DateTime), "1/2/2004", "3/4/2024")]
        public DateTime? ToDate { get; set; }
    }
}
