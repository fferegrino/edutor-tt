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
    public interface IPostSchoolUserMaintenanceProcessor 
    {
        NewSchoolUser AddUser(NewSchoolUser newUser);
    }

    public class PostSchoolUserMaintenanceProcessor : IPostSchoolUserMaintenanceProcessor
    {

        private readonly IAutoMapper _autoMapper;
        private readonly IAddUserQueryProcessor _qProc;
        private readonly IAddSchoolUserQueryProcessor _schUsrQor;

        public PostSchoolUserMaintenanceProcessor(IAutoMapper autoMapper, IAddUserQueryProcessor qProc, IAddSchoolUserQueryProcessor a)
        {
            _autoMapper = autoMapper;
            _qProc = qProc;
            _schUsrQor = a;
        }


        public NewSchoolUser AddUser(NewSchoolUser newUser)
        {
            var userEntity = _autoMapper.Map<Data.Entities.User>(newUser);
            _qProc.AddUser(userEntity);
            //schUserEntity.SchoolUserId = userEntity.UserId;
            var returnUser = _autoMapper.Map<NewSchoolUser>(userEntity);
            //// TODO Implement link service here
            //returnUser.AddLink(new Link { Rel = Constants.CommonLinkRelValues.Self, Method = HttpMethod.Get.Method, Href = "http://www.google.com" });
            return returnUser;
        }
    }
}
