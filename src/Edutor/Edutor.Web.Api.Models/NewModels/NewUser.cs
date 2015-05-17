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

        [Required]
        public string Name { get; set; }

        [StringLength(18,MinimumLength=18)]
        [Required]
        public string Curp { get; set; }


        [EmailAddress]
        [Required]
        public string Email { get; set; }


        [Required]
        public string Address { get; set; }


        [Required]
        public string Mobile { get; set; }


        [Required]
        public string Phone { get; set; }

        public char Type { get; set; }
    }
}
