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
        void AddSelfLink(Event ev);
    }

    public class EventsLinkService : IEventsLinkService
    {

        private readonly ICommonLinkService _cLinkService;
        public EventsLinkService(ICommonLinkService cLinkService)
        {
            _cLinkService = cLinkService;
        }
        public void AddSelfLink(Event ev)
        {
            var pathFragment = String.Format("events/{0}", ev.EventId);
            ev.AddLink(_cLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.Self, HttpMethod.Get));
        }
    }
}
