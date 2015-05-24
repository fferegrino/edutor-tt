﻿using Edutor.Data.QueryProcessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.MaintenanceProcessing
{
    public interface IDeleteGroupsMaintenanceProcessor
    {
        void Delete(int userId);
    }

    public class DeleteGroupsMaintenanceProcessor : IDeleteGroupsMaintenanceProcessor
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
    }
}
