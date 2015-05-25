using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.ReturnTypes
{
    public class Tutor : User
    {
        /// <summary>
        /// Nombre del trabajo del tutor
        /// </summary>
        public string Job { get; set; }

        /// <summary>
        /// Número telefónico del trabajo del tutor
        /// </summary>
        public string JobTelephone { get; set; }
    }
}
