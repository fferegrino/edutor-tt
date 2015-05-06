using Edutor.Common;
using Edutor.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.MaintenanceProcessing
{
    public static class LocationLinkCalculator
    {
        public static Uri GetLocationLink(this ILinkContaining linkContaining)
        {
            if (linkContaining != null && linkContaining.Links != null)
            {
                var locationLink = linkContaining.Links.FirstOrDefault
                    (l => Constants.CommonLinkRelValues.Self.Equals(l.Rel));
                return locationLink == null ? null : new Uri(locationLink.Href);
            }
            return null;
        }
    }
}
