using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.NewModels
{
    public class NewGroup 
    {
        public int GroupId { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(35)]
        public string Subject { get; set; }

        [Required]
        [Range(typeof(DateTime), "1/2/2004", "3/4/2024")]
        public DateTime FromDate { get; set; }


        [Range(typeof(DateTime), "1/2/2004", "3/4/2024")]
        public DateTime? ToDate { get; set; }
        
    }
}
