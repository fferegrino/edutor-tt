using Edutor.Common;
using Edutor.Web.Api.Models;
using Edutor.Web.Api.Models.NewModels;
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
        void AddSelfLink(NewUser user);
    }

    public class UsersLinkService : IUsersLinkService
    {
        private readonly ICommonLinkService _commonLinkService;

        public UsersLinkService(ICommonLinkService commonLinkService)
        {
            _commonLinkService = commonLinkService;
        }

        public void AddSelfLink(NewUser user)
        {
            user.AddLink(GetSelfLink(user));
        }

        public virtual Link GetSelfLink(NewUser user)
        {
            var pathFragment = String.Format((user.Type == Edutor.Data.Entities.User.TutorType ? "tutors/" : "schoolusers/" )+ "{0}",user.UserId);
            var link = _commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.Self, HttpMethod.Get);
            return link;
        }
    }
}