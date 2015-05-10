using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.NewModels
{
    public class NewGroup : ILinkContaining
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        private List<Link> _links;
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
