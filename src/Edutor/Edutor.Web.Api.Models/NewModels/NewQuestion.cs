using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.NewModels
{
    public class NewQuestion
    {
        public int SchoolUserId { get; set; }
        public int GroupId { get; set; }

        [Required]
        [StringLength(100)]
        public string Text { get; set; }

        [Required]
        [Range(typeof(DateTime),"1/1/2004", "1/1/2024")]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public IList<String> PossibleAnswers { get; set; }
    }
}
