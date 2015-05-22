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
    public interface IPatchTutorMaintenanceProcessor
    {
        Tutor UpdateTutor(ModifyTutor schoolUser);
    }


    public class PatchTutorMaintenanceProcessor : IPatchTutorMaintenanceProcessor
    {

        private readonly IAutoMapper _autoMapper;
        private readonly IUpdateUsersQueryProcessor _addUserQueryProcessor;
        private readonly ITutorsLinkService _linkServices;

        public PatchTutorMaintenanceProcessor(IAutoMapper autoMapper,
                    IUpdateUsersQueryProcessor addUserQueryProcessor,
                    ITutorsLinkService linkServices)
        {
            _autoMapper = autoMapper;
            _addUserQueryProcessor = addUserQueryProcessor;
            _linkServices = linkServices;
        }

        public Tutor UpdateTutor(ModifyTutor schoolUser)
        {
            throw new NotImplementedException();
        }
    }
}
