using Edutor.Common.TypeMapping;
using Edutor.Data.QueryProcessors;
using Edutor.Web.Api.Models;
using Edutor.Web.Api.Models.ReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.QueryProcessing
{
    public interface IGetSchoolUsersQueryProcessor 
    {
        SchoolUser GetById(int id);
    }

    public class SchoolUsersQueryProcessor : IGetSchoolUsersQueryProcessor
    {

        
        private readonly IAutoMapper _autoMapper;
        private readonly IGetSchoolUsersQueryProcessors _qProc;

        public SchoolUsersQueryProcessor(IAutoMapper autoMapper, IGetSchoolUsersQueryProcessors qProc)
        {
            _autoMapper = autoMapper;
            _qProc = qProc;
        }


        public SchoolUser GetById(int id)
        {
            return _autoMapper.Map<SchoolUser>(_qProc.GetById(id));
        }
    }
}
