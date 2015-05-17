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
    public interface IUsersLinkService
    {
        void AddAllLinks(User user);
    }

    public class UsersLinkService : IUsersLinkService
    {
        private readonly ICommonLinkService _commonLinkService;

        public UsersLinkService(ICommonLinkService commonLinkService)
        {
            _commonLinkService = commonLinkService;
        }

        public void AddAllLinks(User user)
        {
            var kind = (user.Type == Edutor.Data.Entities.User.TutorType ? "tutors/" : "schoolusers/");
            user.AddLink(GetSelfLink(kind, user));
        }

        public virtual Link GetSelfLink(string kind, User user)
        {
            var pathFragment = String.Format(kind + "{0}", user.UserId);
            var link = _commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.Self, HttpMethod.Get);
            return link;
        }
    }
}