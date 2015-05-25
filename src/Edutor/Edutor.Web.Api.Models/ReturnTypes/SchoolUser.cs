using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.ReturnTypes
{
    /// <summary>
    /// Clase que representa a una usuario escolar
    /// </summary>
    public class SchoolUser : User
    {
        /// <summary>
        /// Describe el puesto que el usuario tiene en el plantel, 'A' para adminsitrador, 'P' para profesor
        /// </summary>
        public string Position { get; set; }
    }
}
