using Edutor.Common;
using Edutor.Web.Api.Models.NewModels;
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

        void AddSelfLink(NewGroup group);
        //void AddTutorLink(NewGroup group);
    }

    public class GroupsLinkService : IGroupsLinkService
    {

        private readonly ICommonLinkService _commonLinkService;

        public GroupsLinkService(ICommonLinkService commonLinkService)
        {
            _commonLinkService = commonLinkService;
        }
        public void AddSelfLink(NewGroup group)
        {
            var pathFragment = String.Format("groups/{0}", group.GroupId);
            group.AddLink(_commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.Self, HttpMethod.Get));
        }
    }
}
