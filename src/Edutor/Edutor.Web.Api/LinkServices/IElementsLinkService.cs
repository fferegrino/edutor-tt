using Edutor.Common;
using Edutor.Web.Api.Models;
using Edutor.Web.Api.Models.NewModels;
using Edutor.Web.Api.Models.ReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.LinkServices
{
    public interface IElementsLinkService
    {

        void AddAllLinks(StudentAnswer studentAnswer);

        void AddAllLinks(StudentInvitation studentInvitation);

        void AddAllLinks(StudentNotification studentNotification);
    }

    public class ElementsLinkService : IElementsLinkService
    {
        private readonly ICommonLinkService _commonLinkService;

        public ElementsLinkService(ICommonLinkService commonLinkService)
        {
            _commonLinkService = commonLinkService;
        }

        public void AddSelfLink(BasicStudent user)
        {
            user.AddLink(GetSelfLink(user));
        }


        public virtual Link GetSelfLink(BasicStudent user)
        {
            var pathFragment = String.Format("students/{0}", user.StudentId);
            var link = _commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.Self, HttpMethod.Get);
            return link;
        }

        public void AddAllLinks(BasicStudent student)
        {
            var studentLinks = String.Format("students/{0}", student.StudentId);
            student.AddLink(_commonLinkService.GetLink(studentLinks, Constants.CommonLinkRelValues.StudentRel, HttpMethod.Get));
        }

        public void AddAllLinks(StudentAnswer s)
        {
            var studentAnswerLinks = String.Format("questions/{0}/answers/{1}", s.QuestionId, s.StudentId);
            s.AddLink(_commonLinkService.GetLink(studentAnswerLinks, Constants.CommonLinkRelValues.Self, HttpMethod.Get));
            s.AddLink(_commonLinkService.GetLink(studentAnswerLinks, Constants.CommonLinkRelValues.AnswerRel, HttpMethod.Put));

        }

        public void AddAllLinks(StudentInvitation s)
        {
            var studentAnswerLinks = String.Format("events/{0}/attendees/{1}", s.EventId, s.StudentId);
            s.AddLink(_commonLinkService.GetLink(studentAnswerLinks, Constants.CommonLinkRelValues.Self, HttpMethod.Get));
            s.AddLink(_commonLinkService.GetLink(studentAnswerLinks, Constants.CommonLinkRelValues.RsvpRel, HttpMethod.Put));
        }

        public void AddAllLinks(StudentNotification s)
        {
            var studentAnswerLinks = String.Format("notifications/{0}/details/{1}", s.NotificationId, s.StudentId);
            s.AddLink(_commonLinkService.GetLink(studentAnswerLinks, Constants.CommonLinkRelValues.Self, HttpMethod.Get));
            s.AddLink(_commonLinkService.GetLink(studentAnswerLinks, Constants.CommonLinkRelValues.SeenRel, HttpMethod.Put));
        }
    }
}