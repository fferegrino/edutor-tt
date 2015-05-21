using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.NewModels
{
    public class NewEvent
    {
        public int SchoolUserId { get; set; }

        public int GroupId { get; set; }

        [Required]
        [StringLength(60)]
        public string Name { get; set; }

        [Required]
        [Range(typeof(DateTime), "1/2/2004", "3/4/2024")]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        public int EventId { get; set; }
    }
}
