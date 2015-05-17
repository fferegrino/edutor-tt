using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Edutor.Web.Api.Models.NewModels
{
    public class NewSchoolUser : NewUser
    {
        [Required]
        public char Position { get; set; }
    }
}
