using Edutor.Data.QueryProcessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.MaintenanceProcessing
{
    public interface IDeleteStudentMaintenanceProcessor
    {
        void Delete(int studentId);
    }

    public class DeleteStudentMaintenanceProcessor : IDeleteStudentMaintenanceProcessor
    {
        private readonly IDeleteStudentQueryProcessor _deleteUserQ;

        public DeleteStudentMaintenanceProcessor(IDeleteStudentQueryProcessor deleteUserQ)
        {
            _deleteUserQ = deleteUserQ;
        }

        public void Delete(int studentId)
        {
            _deleteUserQ.Delete(studentId);
        }
    }
}
