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
    public interface IPatchSchoolUserMaintenanceProcessor
    {
        SchoolUser UpdateSchoolUser(ModifySchoolUser schoolUser);
    }


    public class PatchSchoolUserMaintenanceProcessor : IPatchSchoolUserMaintenanceProcessor
    {
        
        private readonly IAutoMapper _autoMapper;
        private readonly IUpdateUsersQueryProcessor _addUserQueryProcessor;
        private readonly ISchoolUsersLinkService _linkServices;

        public PatchSchoolUserMaintenanceProcessor(IAutoMapper autoMapper,
                    IUpdateUsersQueryProcessor addUserQueryProcessor,
                    ISchoolUsersLinkService linkServices)
        {
            _autoMapper = autoMapper;
            _addUserQueryProcessor = addUserQueryProcessor;
            _linkServices = linkServices;
        }


        public SchoolUser UpdateSchoolUser(ModifySchoolUser schoolUser)
        {
            throw new NotImplementedException();
        }
    }
}
