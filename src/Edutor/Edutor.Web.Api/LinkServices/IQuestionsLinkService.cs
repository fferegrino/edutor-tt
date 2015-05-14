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
        void AddSelfLink(Question ev);
    }

    public class QuestionsLinkService : IQuestionsLinkService
    {

        private readonly ICommonLinkService _cLinkService;

        public QuestionsLinkService(ICommonLinkService cLinkService)
        {
            _cLinkService = cLinkService;
        }
        public void AddSelfLink(Question ev)
        {
            var pathFragment = String.Format("questions/{0}", ev.QuestionId);
            ev.AddLink(_cLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.Self, HttpMethod.Get));
        }
    }
}
