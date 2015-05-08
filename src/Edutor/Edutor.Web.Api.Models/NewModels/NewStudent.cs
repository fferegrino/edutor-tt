using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.NewModels
{
    public class NewStudent : ILinkContaining
    {

        public int StudentId { get; set; }
        public int TutorId { get; set; }
        public string TutorRelationship { get; set; }
        //public bool IsActive { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Curp { get; set; }
        public string Name { get; set; }
        //public string Token { get; set; }

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
