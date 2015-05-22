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
    public interface IPatchStudentMaintenanceProcessor
    {
        Student UpdateStudent(ModifyStudent schoolUser);
    }


    public class PatchStudentMaintenanceProcessor : IPatchStudentMaintenanceProcessor
    {

        private readonly IAutoMapper _autoMapper;
        private readonly IUpdateStudentsQueryProcessor _addUserQueryProcessor;
        private readonly IStudentsLinkService _linkServices;

        public PatchStudentMaintenanceProcessor(IAutoMapper autoMapper,
                    IUpdateStudentsQueryProcessor addUserQueryProcessor,
                    IStudentsLinkService linkServices)
        {
            _autoMapper = autoMapper;
            _addUserQueryProcessor = addUserQueryProcessor;
            _linkServices = linkServices;
        }

        public Student UpdateStudent(ModifyStudent schoolUser)
        {
            throw new NotImplementedException();
        }
    }
}
