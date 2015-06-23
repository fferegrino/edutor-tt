using Edutor.Data.QueryProcessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.MaintenanceProcessing
{
    public interface IDeleteInteracionsMaintenanceProcessor
    {
        void DeleteQuestion(int questionId);

        void DeleteEvent(int eventId);

        void DeleteNotification(int notificationId);
    }

    public class DeleteInteracionsMaintenanceProcessor : IDeleteInteracionsMaintenanceProcessor
    {
        private readonly IDeleteInteractionsQueryProcessor _deleteStuff;

        public DeleteInteracionsMaintenanceProcessor(IDeleteInteractionsQueryProcessor deleteUserQ)
        {
            _deleteStuff = deleteUserQ;
        }


        public void DeleteQuestion(int questionId)
        {
            _deleteStuff.DeleteQuestion(questionId);
        }

        public void DeleteEvent(int eventId)
        {
            _deleteStuff.DeleteEvent(eventId);
        }

        public void DeleteNotification(int notificationId)
        {
            _deleteStuff.DeleteNotification(notificationId);
        }
    }
}
