using Edutor.Data.QueryProcessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.MaintenanceProcessing
{
    public interface IDeleteUserMaintenanceProcessing
    {
        void Delete(int userId);
    }

    public class DeleteUsersMaintenanceProcessing : IDeleteUserMaintenanceProcessing
    {
        private readonly IDeleteUserQueryProcessor _deleteUserQ;

        public DeleteUsersMaintenanceProcessing(IDeleteUserQueryProcessor deleteUserQ)
        {
            _deleteUserQ = deleteUserQ;
        }

        public void Delete(int userId)
        {
            _deleteUserQ.Delete(userId);
        }
    }
}
