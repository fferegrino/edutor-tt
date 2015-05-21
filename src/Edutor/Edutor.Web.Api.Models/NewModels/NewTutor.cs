using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.NewModels
{
    public class NewTutor : NewUser
    {
        [StringLength(20)]
        public string Job { get; set; }

        [StringLength(10)]
        public string JobTelephone { get; set; }
    }
}
