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
    public interface IPatchTutorMaintenanceProcessor
    {
        Tutor UpdateTutor(ModifiableTutor schoolUser);
    }


    public class PatchTutorMaintenanceProcessor : IPatchTutorMaintenanceProcessor
    {

        private readonly IAutoMapper _autoMapper;
        private readonly IUpdateUsersQueryProcessor _addUserQueryProcessor;
        private readonly IGetUsersQueryProcessor _getTutor;
        private readonly ITutorsLinkService _linkServices;

        public PatchTutorMaintenanceProcessor(IAutoMapper autoMapper,
                    IUpdateUsersQueryProcessor addUserQueryProcessor,
            IGetUsersQueryProcessor getTutor,
                    ITutorsLinkService linkServices)
        {
            _getTutor = getTutor;
            _autoMapper = autoMapper;
            _addUserQueryProcessor = addUserQueryProcessor;
            _linkServices = linkServices;
        }

        public Tutor UpdateTutor(ModifiableTutor schoolUser)
        {
            var entTutor = _autoMapper.Map<Ent.User>(schoolUser);
            var notUpdated = _getTutor.GetTutor(schoolUser.UserId);
            #region Update
            notUpdated.Name = schoolUser.Name ?? notUpdated.Name;
            notUpdated.Email = schoolUser.Email ?? notUpdated.Email;
            notUpdated.Address = schoolUser.Address ?? notUpdated.Address;
            notUpdated.Mobile = schoolUser.Mobile ?? notUpdated.Mobile;
            notUpdated.Phone = schoolUser.Phone ?? notUpdated.Phone;
            notUpdated.Job = schoolUser.Job ?? notUpdated.Job;
            notUpdated.JobTelephone = schoolUser.JobTelephone ?? notUpdated.JobTelephone;
            #endregion
            _addUserQueryProcessor.Update(notUpdated);
            var ret = _autoMapper.Map<Tutor>(notUpdated);
            _linkServices.AddAllLinks(ret);
            return ret;
        }
    }
}
