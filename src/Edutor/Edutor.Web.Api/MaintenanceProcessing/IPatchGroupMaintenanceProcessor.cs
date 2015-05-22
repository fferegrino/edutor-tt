using Edutor.Common.TypeMapping;
using Edutor.Data.QueryProcessors;
using Edutor.Web.Api.LinkServices;
using Edutor.Web.Api.Models.ModModels;
using Edutor.Web.Api.Models.ReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.MaintenanceProcessing
{
    public interface IPatchGroupMaintenanceProcessor
    {
        Group UpdateGroup(ModifyGroup grpup);
    }


    public class PatchGroupMaintenanceProcessor : IPatchGroupMaintenanceProcessor
    {

        private readonly IAutoMapper _autoMapper;
        private readonly IUpdateGroupsQueryProcessor _addUserQueryProcessor;
        private readonly IGroupsLinkService _linkServices;

        public PatchGroupMaintenanceProcessor(IAutoMapper autoMapper,
            IUpdateGroupsQueryProcessor addUserQueryProcessor,
            IGroupsLinkService linkServices)
        {
            _autoMapper = autoMapper;
            _addUserQueryProcessor = addUserQueryProcessor;
            _linkServices = linkServices;
        }

        public Group UpdateGroup(ModifyGroup grpup)
        {
            throw new NotImplementedException();
        }
    }
}
