using Edutor.Common;
using Edutor.Common.TypeMapping;
using Edutor.Data.QueryProcessors;
using Edutor.Web.Api.Models;
using Edutor.Web.Api.Models.NewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.MaintenanceProcessing
{
    public interface IPostTutorMaintenanceProcessor
    {
        NewTutor AddUser(NewTutor newTutor);
    }
    public class PostTutorMaintenanceProcessor : IPostTutorMaintenanceProcessor
    {

        private readonly IAutoMapper _autoMapper;
        private readonly IAddUserQueryProcessor _addUserQueryProcessor;

        public PostTutorMaintenanceProcessor(IAutoMapper autoMapper, IAddUserQueryProcessor addUserQueryProcessor, IAddSchoolUserQueryProcessor a)
        {
            _autoMapper = autoMapper;
            _addUserQueryProcessor = addUserQueryProcessor; ;
        }


        public NewTutor AddUser(NewTutor newUser)
        {
            var userEntity = _autoMapper.Map<Data.Entities.User>(newUser);
            _addUserQueryProcessor.AddUser(userEntity);
            var returnUser = _autoMapper.Map<NewTutor>(userEntity);

            // TODO Implement link service here
            returnUser.AddLink(new Link { Rel = Constants.CommonLinkRelValues.Self, Method = HttpMethod.Get.Method, Href = "http://www.google.com" });

            return returnUser;
        }
    }
}
