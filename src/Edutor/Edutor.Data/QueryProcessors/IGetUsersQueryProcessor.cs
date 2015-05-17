using Edutor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.QueryProcessors
{
    public interface IGetUsersQueryProcessor
    {
        QueryResult<User> GetSchoolUsers(PagedDataRequest requestInfo);

        QueryResult<User> GetTutors(PagedDataRequest requestInfo);

        User GetSchoolUser(int userId);

        User GetTutor(int userId);

        QueryResult<User> GetSchoolUsersForGroup(int groupId, PagedDataRequest requestInfo);
    }
}
