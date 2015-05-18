
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.ReturnTypes
{
    public class StudentAnswer : BasicStudent
    {
        public int SchoolUserId { get; set; }
        public int QuestionId { get; set; }
        public int GroupId { get; set; }
        public string Text { get; set; }
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        
    }
}
