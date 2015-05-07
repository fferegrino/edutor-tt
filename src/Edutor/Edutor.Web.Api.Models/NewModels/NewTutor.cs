using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.NewModels
{
    public class NewTutor : NewUser
    {
        public string Job { get; set; }
        public string JobTelephone { get; set; }
    }
}
