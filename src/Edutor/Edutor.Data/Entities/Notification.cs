﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.Entities
{
    public class Notification : IVersionedEntity
    {
        public virtual byte[] Version { get; set; }
    }
}