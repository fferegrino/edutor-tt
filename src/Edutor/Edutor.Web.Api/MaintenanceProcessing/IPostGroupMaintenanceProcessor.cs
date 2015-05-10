using Edutor.Common.TypeMapping;
using Edutor.Data.QueryProcessors;
using Edutor.Web.Api.LinkServices;
using Edutor.Web.Api.Models.NewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.MaintenanceProcessing
{
    public interface IPostGroupMaintenanceProcessor
    {
        NewGroup AddGroup(NewGroup group);
    }

    public class PostGroupMaintenanceProcessor : IPostGroupMaintenanceProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly IAddGroupQueryProcessor _addUserQueryProcessor;
        private readonly IGroupsLinkService _linkServices;

        public PostGroupMaintenanceProcessor(IAutoMapper autoMapper, IAddGroupQueryProcessor addUserQueryProcessor, IGroupsLinkService linkServices)
        {
            _autoMapper = autoMapper;
            _addUserQueryProcessor = addUserQueryProcessor;
            _linkServices = linkServices;
        }


        public NewGroup AddGroup(NewGroup newGroup)
        {

            var userEntity = _autoMapper.Map<Data.Entities.Group>(newGroup);
            _addUserQueryProcessor.AddGroup(userEntity);


            newGroup.GroupId = userEntity.GroupId;

            // TODO Implement link service here
            _linkServices.AddSelfLink(newGroup);

            return newGroup;
        }
    }
}
