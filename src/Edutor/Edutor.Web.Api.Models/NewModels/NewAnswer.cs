using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.NewModels
{
    public class NewAnswer
    {
        public int SelectedAnswerId { get; set; }
        public int StudentId { get; set; }
        public int QuestionId { get; set; }

    }
}
