﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.QueryProcessors
{
    public interface IAddTeachingQueryProcessor
    {
        void AddEnrollment(Entities.Teaching teaching);
    }
}
