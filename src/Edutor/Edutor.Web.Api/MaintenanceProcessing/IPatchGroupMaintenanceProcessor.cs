using Edutor.Common.TypeMapping;
using Ent = Edutor.Data.Entities;
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
        Group UpdateGroup(ModifiableGroup grpup);
    }


    public class PatchGroupMaintenanceProcessor : IPatchGroupMaintenanceProcessor
    {

        private readonly IAutoMapper _autoMapper;
        private readonly IUpdateGroupsQueryProcessor _addUserQueryProcessor;
        private readonly IGetGroupsQueryProcessor _getGroups;
        private readonly IGroupsLinkService _linkServices;

        public PatchGroupMaintenanceProcessor(IAutoMapper autoMapper,
            IUpdateGroupsQueryProcessor addUserQueryProcessor,
            IGetGroupsQueryProcessor getGroups,
            IGroupsLinkService linkServices)
        {
            _autoMapper = autoMapper;
            _addUserQueryProcessor = addUserQueryProcessor;
            _linkServices = linkServices;
            _getGroups = getGroups;
        }

        public Group UpdateGroup(ModifiableGroup grpup)
        {
            var entTutor = _autoMapper.Map<Ent.Group>(grpup);

            var notUpdated = _getGroups.GetGroup(grpup.GroupId);

            #region Update
            notUpdated.Name = grpup.Name ?? notUpdated.Name;
            notUpdated.Subject = grpup.Subject ?? notUpdated.Subject;
            notUpdated.FromDate = grpup.FromDate ?? notUpdated.FromDate;
            #endregion
            _addUserQueryProcessor.Update(notUpdated);

            var ret = _autoMapper.Map<Group>(notUpdated);
            _linkServices.AddAllLinks(ret);
            return ret;
        }
    }
}
