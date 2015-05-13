using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edutor.Web.Api.Models.ReturnTypes
{
    public class PossibleAnswer : LinkContaining
    {
        public int QuestionId { get; set; }
        public int PossibleAnswerId { get; set; }
        public string Text { get; set; }
    }
}
