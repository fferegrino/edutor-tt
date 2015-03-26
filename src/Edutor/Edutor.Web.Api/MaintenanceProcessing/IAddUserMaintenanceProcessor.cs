using Edutor.Common.TypeMapping;
using Edutor.Data.QueryProcessors;
using Edutor.Web.Api.Models;
using Edutor.Web.Api.Models.NewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.MaintenanceProcessing
{
    public interface IAddUserMaintenanceProcessor 
    {
        User AddUser(NewUser newUser);
    }

    public class AddUserMaintenanceProcessor : IAddUserMaintenanceProcessor
    {

        private readonly IAutoMapper _autoMapper;
        private readonly IAddUserQueryProcessor _qProc;

        public AddUserMaintenanceProcessor(IAutoMapper autoMapper, IAddUserQueryProcessor qProc)
        {
            _autoMapper = autoMapper;
            _qProc = qProc;
        }
    

        public User AddUser(NewUser newUser)
        {
            var userEntity = _autoMapper.Map<Data.Entities.User>(newUser);
            _qProc.AddUser(userEntity);
            return new User();
        }
    }
}
