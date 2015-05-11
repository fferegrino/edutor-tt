using Edutor.Common;
using Edutor.Common.TypeMapping;
using Edutor.Data.QueryProcessors;
using Edutor.Web.Api.LinkServices;
using Edutor.Web.Api.Models;
using Edutor.Web.Api.Models.NewModels;
using Edutor.Web.Api.Models.ReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.MaintenanceProcessing
{
    public interface IPostSchoolUserMaintenanceProcessor 
    {
        SchoolUser AddUser(NewSchoolUser newUser);
    }

    public class PostSchoolUserMaintenanceProcessor : IPostSchoolUserMaintenanceProcessor
    {

        private readonly IAutoMapper _autoMapper;
        
        private readonly IAddUserQueryProcessor _addUserQueryProcessor;
        private readonly IUsersLinkService _linkServices;

        public PostSchoolUserMaintenanceProcessor(IAutoMapper autoMapper, IAddUserQueryProcessor addUserQueryProcessor, IUsersLinkService linkServices)
        {
            _autoMapper = autoMapper;
            _addUserQueryProcessor = addUserQueryProcessor;
            _linkServices = linkServices;
        }


        public SchoolUser AddUser(NewSchoolUser newUser)
        {
            var userEntity = _autoMapper.Map<Data.Entities.User>(newUser);
            _addUserQueryProcessor.AddUser(userEntity);
            var returnType = _autoMapper.Map<SchoolUser>(userEntity);
            // TODO Implement link service here
            _linkServices.AddSelfLink(returnType);

            return returnType;
        }
    }
}
