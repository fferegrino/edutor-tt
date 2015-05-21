using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.NewModels
{
    public class NewStudent
    {

        public int StudentId { get; set; }

        public int TutorId { get; set; }

        [StringLength(3)]
        public string TutorRelationship { get; set; }

        public bool IsActive { get; set; }

        [Required]
        [StringLength(512)]
        public string Address { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }

        [Required]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "La CURP consta de 18 caracteres")]
        public string Curp { get; set; }

        [Required]
        [StringLength(60)]
        public string Name { get; set; }

    }
}
