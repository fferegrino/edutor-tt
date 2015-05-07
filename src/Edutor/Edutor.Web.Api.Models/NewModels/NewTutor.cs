using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.NewModels
{
    public class NewTutor : ILinkContaining
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Curp { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Job { get; set; }
        public string JobTelephone { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }

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
