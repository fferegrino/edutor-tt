using Edutor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.QueryProcessors
{
    public interface IGetNotificationsQueryProcessor
    {
        QueryResult<Notification> GetNotificationsForSchoolUser(int schoolUser, PagedDataRequest requestInfo);

        QueryResult<NotificationDetail> GetNotificationsForStudent(int studentId, PagedDataRequest requestInfo);

        Notification GetNotification(int notificationId);

    }
}
