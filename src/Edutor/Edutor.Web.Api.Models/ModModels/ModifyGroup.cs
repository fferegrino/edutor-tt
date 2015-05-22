using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.ModModels
{
    public class ModifyGroup
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
