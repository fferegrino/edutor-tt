using Edutor.Common;
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
    public interface IGroupsLinkService
    {

        void AddAllLinks(Group group);

        void AddSelfLink(Group group);
        //void AddTutorLink(NewGroup group);
    }

    public class GroupsLinkService : IGroupsLinkService
    {

        private readonly ICommonLinkService _commonLinkService;

        public GroupsLinkService(ICommonLinkService commonLinkService)
        {
            _commonLinkService = commonLinkService;
        }
        public void AddSelfLink(Group group)
        {
        }

        public void AddAllLinks(Group group)
        {

            string pathFragment = String.Format("groups/{0}", group.GroupId);
            group.AddLink(_commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.Self, HttpMethod.Get));

            pathFragment = String.Format("groups/{0}/students", group.GroupId);
            group.AddLink(_commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.StudentsRel, HttpMethod.Get));

            pathFragment = String.Format("groups/{0}/schoolusers", group.GroupId);
            group.AddLink(_commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.SchoolUsersRel, HttpMethod.Get));
        }
    }
}
