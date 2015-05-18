using Edutor.Common;
using Edutor.Web.Api.Models;
using Edutor.Web.Api.Models.NewModels;
using Edutor.Web.Api.Models.ReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.LinkServices
{
    public interface ITutorsLinkService
    {
        void AddAllLinks(User user);
    }

    public class TutorsLinkService : ITutorsLinkService
    {
        private readonly ICommonLinkService _commonLinkService;

        public TutorsLinkService(ICommonLinkService commonLinkService)
        {
            _commonLinkService = commonLinkService;
        }

        public void AddAllLinks(User user)
        {
            var pathFragment = String.Format("tutors/{0}", user.UserId);
            user.AddLink(_commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.Self, HttpMethod.Get));

            user.AddLink(_commonLinkService.GetLink(pathFragment + "/students", Constants.CommonLinkRelValues.StudentsRel, HttpMethod.Get));
        }

    }
}