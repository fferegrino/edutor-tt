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
    public interface IPatchSchoolUserMaintenanceProcessor
    {
        SchoolUser UpdateSchoolUser(ModifiableSchoolUser schoolUser);
    }


    public class PatchSchoolUserMaintenanceProcessor : IPatchSchoolUserMaintenanceProcessor
    {
        
        private readonly IAutoMapper _autoMapper;
        private readonly IUpdateUsersQueryProcessor _addUserQueryProcessor;
        private readonly IGetUsersQueryProcessor _getSchoolUsers;
        private readonly ISchoolUsersLinkService _linkServices;

        public PatchSchoolUserMaintenanceProcessor(IAutoMapper autoMapper,
                    IUpdateUsersQueryProcessor addUserQueryProcessor,
            IGetUsersQueryProcessor getSchoolUsers,
                    ISchoolUsersLinkService linkServices)
        {
            _getSchoolUsers = getSchoolUsers;
            _autoMapper = autoMapper;
            _addUserQueryProcessor = addUserQueryProcessor;
            _linkServices = linkServices;
        }


        public SchoolUser UpdateSchoolUser(ModifiableSchoolUser schoolUser)
        {
            var entTutor = _autoMapper.Map<Ent.User>(schoolUser);
            var notUpdated = _getSchoolUsers.GetSchoolUser(schoolUser.UserId);
            #region Update
            notUpdated.Name = schoolUser.Name ?? notUpdated.Name;
            notUpdated.Email = schoolUser.Email ?? notUpdated.Email;
            notUpdated.Address = schoolUser.Address ?? notUpdated.Address;
            notUpdated.Mobile = schoolUser.Mobile ?? notUpdated.Mobile;
            notUpdated.Phone = schoolUser.Phone ?? notUpdated.Phone;
            notUpdated.Position = schoolUser.Position ?? notUpdated.Position;
            #endregion
            _addUserQueryProcessor.Update(notUpdated);
            var ret = _autoMapper.Map<SchoolUser>(notUpdated);
            _linkServices.AddAllLinks(ret);
            return ret;
        }
    }
}
