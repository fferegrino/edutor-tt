using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.NewModels
{
    public class NewNotification
    {
        public int SchoolUserId { get; set; }
        public int GroupId { get; set; }

        [Required]
        [StringLength(300)]
        public string Text { get; set; }
    }
}
