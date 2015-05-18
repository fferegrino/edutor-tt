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
    public interface ISchoolUsersLinkService
    {
        void AddAllLinks(User user);
    }

    public class SchoolUsersLinkService : ISchoolUsersLinkService
    {
        private readonly ICommonLinkService _commonLinkService;

        public SchoolUsersLinkService(ICommonLinkService commonLinkService)
        {
            _commonLinkService = commonLinkService;
        }

        public void AddAllLinks(User user)
        {
            var pathFragment = String.Format("schoolusers/{0}", user.UserId);
            user.AddLink(_commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.Self, HttpMethod.Get));

            user.AddLink(_commonLinkService.GetLink(pathFragment + "/groups", Constants.CommonLinkRelValues.GroupsRel, HttpMethod.Get));
        }

    }
}