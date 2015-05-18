using Edutor.Web.Api.Models.ReturnTypes;
using Edutor.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.LinkServices
{
    public interface IQuestionsLinkService
    {
        void AddAllLinks(Question ev);
    }

    public class QuestionsLinkService : IQuestionsLinkService
    {

        private readonly ICommonLinkService _l;

        public QuestionsLinkService(ICommonLinkService cLinkService)
        {
            _l = cLinkService;
        }
        public void AddAllLinks(Question ev)
        {
            var pathFragment = String.Format("questions/{0}", ev.QuestionId);
            ev.AddLink(_l.GetLink(pathFragment, Constants.CommonLinkRelValues.Self, HttpMethod.Get));

            ev.AddLink(_l.GetLink(pathFragment + "/answers", Constants.CommonLinkRelValues.AnswersRel, HttpMethod.Get));

            ev.AddLink(_l.GetLink(String.Format("schoolusers/{0}", ev.SchoolUserId), Constants.CommonLinkRelValues.SchoolUserRel, HttpMethod.Get));
        }
    }
}
