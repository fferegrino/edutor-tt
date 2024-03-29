﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.QueryProcessors
{
    public interface IDeleteGroupQueryProcessor
    {
        void Delete(int grouopId);

        void UnlinkStudent(int groupId, int studentId);

        void UnlinkSchoolUser(int groupId, int schoolUserId);
    }

}
