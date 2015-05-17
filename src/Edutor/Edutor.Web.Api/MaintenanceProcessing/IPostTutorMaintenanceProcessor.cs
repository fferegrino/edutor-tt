using Edutor.Common;
using Edutor.Common.TypeMapping;
using Edutor.Data.QueryProcessors;
using Edutor.Web.Api.LinkServices;
using Edutor.Web.Api.Models;
using Edutor.Web.Api.Models.NewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Edutor.Web.Api.Models.ReturnTypes;

namespace Edutor.Web.Api.MaintenanceProcessing
{
    public interface IPostTutorMaintenanceProcessor
    {
        Tutor AddUser(NewTutor newTutor);
    }
    public class PostTutorMaintenanceProcessor : IPostTutorMaintenanceProcessor
    {

        private readonly IAutoMapper _autoMapper;
        private readonly IAddUserQueryProcessor _addUserQueryProcessor;
        private readonly IUsersLinkService _linkServices;

        public PostTutorMaintenanceProcessor(IAutoMapper autoMapper, IAddUserQueryProcessor addUserQueryProcessor, IUsersLinkService linkServices)
        {
            _autoMapper = autoMapper;
            _addUserQueryProcessor = addUserQueryProcessor;
            _linkServices = linkServices;
        }


        public Tutor AddUser(NewTutor newUser)
        {
            var userEntity = _autoMapper.Map<Data.Entities.User>(newUser);
            _addUserQueryProcessor.AddUser(userEntity);
            var returnUser = _autoMapper.Map<Tutor>(userEntity);

            _linkServices.AddAllLinks(returnUser);

            return returnUser;
        }
    }
}
