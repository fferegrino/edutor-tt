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
        [StringLength(70)]
        public string Name { get; set; }

        [StringLength(18,MinimumLength=18)]
        [Required]
        public string Curp { get; set; }


        [EmailAddress]
        [Required]
        [StringLength(60)]
        public string Email { get; set; }


        [Required]
        [StringLength(512)]
        public string Address { get; set; }

        [StringLength(10)]
        public string Mobile { get; set; }


        [StringLength(10)]
        public string Phone { get; set; }

        public char Type { get; set; }
    }
}
