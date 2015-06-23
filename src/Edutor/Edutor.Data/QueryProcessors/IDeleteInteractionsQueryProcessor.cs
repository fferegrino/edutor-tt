using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.QueryProcessors
{
    public interface IDeleteInteractionsQueryProcessor
    {
        void DeleteQuestion(int questionId);

        void DeleteEvent(int eventId);

        void DeleteNotification(int notificationId);
    }

}