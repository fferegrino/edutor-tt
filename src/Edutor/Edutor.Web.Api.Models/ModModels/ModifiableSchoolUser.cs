using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.ModModels
{
    public class ModifiableSchoolUser : ModifiableUser
    {
        /// <summary>
        /// La posición que ocupa el usuario escolar dentro de la escuela: <code>A</code> para administrador, <code>P</code> para profesor
        /// </summary>
        public char? Position { get; set; }
    }
}
