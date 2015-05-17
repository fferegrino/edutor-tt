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
    public interface INotificationsLinkService
    {
        void AddAllLinks(Notification ev);
    }

    public class NotificationsLinkService : INotificationsLinkService
    {

        private readonly ICommonLinkService _cLinkService;

        public NotificationsLinkService(ICommonLinkService cLinkService)
        {
            _cLinkService = cLinkService;
        }
        public void AddAllLinks(Notification ev)
        {
            var pathFragment = String.Format("notifications/{0}", ev.NotificationId);
            ev.AddLink(_cLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.Self, HttpMethod.Get));
        }
    }
}
