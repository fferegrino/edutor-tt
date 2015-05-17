﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models
{
    public interface IPageLinkContaining : ILinkContaining
    {
        int PageNumber { get; set; }
        int PageCount { get; set; }
        int PageSize { get; set; }
    }
}
