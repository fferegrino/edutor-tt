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

        private readonly ICommonLinkService _l;

        public NotificationsLinkService(ICommonLinkService cLinkService)
        {
            _l = cLinkService;
        }
        public void AddAllLinks(Notification ev)
        {
            var pathFragment = String.Format("notifications/{0}", ev.NotificationId);
            ev.AddLink(_l.GetLink(pathFragment, Constants.CommonLinkRelValues.Self, HttpMethod.Get));

            ev.AddLink(_l.GetLink(pathFragment + "/details", Constants.CommonLinkRelValues.NotificationDetailsRel, HttpMethod.Get));

            ev.AddLink(_l.GetLink(String.Format("schoolusers/{0}", ev.SchoolUserId), Constants.CommonLinkRelValues.SchoolUserRel, HttpMethod.Get));
        }
    }
}
