using Edutor.Data.QueryProcessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.MaintenanceProcessing
{
    public interface IDeleteGroupMaintenanceProcessor
    {
        void Delete(int userId);

        void UnlinkStudent(int groupId, int studentId);

        void UnlinkSchoolUser(int groupId, int schoolUserId);
    }

    public class DeleteGroupsMaintenanceProcessor : IDeleteGroupMaintenanceProcessor
    {
        private readonly IDeleteGroupQueryProcessor _deleteUserQ;

        public DeleteGroupsMaintenanceProcessor(IDeleteGroupQueryProcessor deleteUserQ)
        {
            _deleteUserQ = deleteUserQ;
        }

        public void Delete(int userId)
        {
            _deleteUserQ.Delete(userId);
        }


        public void UnlinkStudent(int groupId, int studentId)
        {
            _deleteUserQ.UnlinkStudent(groupId, studentId);
        }

        public void UnlinkSchoolUser(int groupId, int schoolUserId)
        {
            _deleteUserQ.UnlinkSchoolUser(groupId, schoolUserId);
        }
    }
}
