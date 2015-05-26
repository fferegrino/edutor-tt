using Edutor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.QueryProcessors
{
    public interface IGetGroupsQueryProcessor
    {
        QueryResult<Group> GetGroups(PagedDataRequest requestInfo);


        Group GetGroup(int groupId);


        QueryResult<Group> GetGroupsForSchoolUser(int schoolUserId, PagedDataRequest requestInfo);

        Group GetGroup(string name);
    }
}
