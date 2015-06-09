using Edutor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.QueryProcessors
{
    public interface IGetEventsQueryProcessor
    {
        QueryResult<Event> GetEventsForSchoolUser(int schoolUser, PagedDataRequest requestInfo);

        QueryResult<Invitation> GetEventsForStudent(int studentId, PagedDataRequest requestInfo);

        QueryResult<Event> GetEventsForSchoolUser(int schoolUser, int groupId, PagedDataRequest requestInfo);

        Event GetEvent(int eventId);

    }
}
