
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.ReturnTypes
{
    public class Question : LinkContaining
    {
        public int SchoolUserId { get; set; }
        public int GroupId { get; set; }
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public DateTime ExpirationDate { get; set; }
        public IList<PossibleAnswer> PossibleAnswers { get; set; }
        
    }
}
