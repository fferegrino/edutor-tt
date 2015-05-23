using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models
{
    public class PagedDataResponse<T> : IPageLinkContaining
    {
        private List<Link> _links;
        private List<T> _items;

        public int PageCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public List<T> Items
        {
            get { return _items ?? (_items = new List<T>()); }
            set { _items = value; }
        }

        public List<Link> Links
        {
            get { return _links ?? (_links = new List<Link>()); }
            set { _links = value; }
        }

        public void AddLink(Link link)
        {
            Links.Add(link);
        }
    }
}
