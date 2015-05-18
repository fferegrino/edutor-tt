using Edutor.Web.Api.Models.ReturnTypes;
using Edutor.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.LinkServices
{
    public interface IEventsLinkService
    {
        void AddAllLinks(Event ev);
    }

    public class EventsLinkService : IEventsLinkService
    {

        private readonly ICommonLinkService _l;
        public EventsLinkService(ICommonLinkService cLinkService)
        {
            _l = cLinkService;
        }
        public void AddAllLinks(Event ev)
        {
            var pathFragment = String.Format("events/{0}", ev.EventId);
            ev.AddLink(_l.GetLink(pathFragment, Constants.CommonLinkRelValues.Self, HttpMethod.Get));

            ev.AddLink(_l.GetLink(pathFragment + "/attendees", Constants.CommonLinkRelValues.AttendeesRel, HttpMethod.Get));

            ev.AddLink(_l.GetLink(String.Format("schoolusers/{0}", ev.SchoolUserId), Constants.CommonLinkRelValues.SchoolUserRel, HttpMethod.Get));
        }
    }
}
