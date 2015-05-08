using Edutor.Common;
using Edutor.Web.Api.Models;
using Edutor.Web.Api.Models.NewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.LinkServices
{
    public interface IStudentsLinkService
    {
        void AddSelfLink(NewStudent user);
        void AddTutorLink(NewStudent user);
    }

    public class StudentsLinkService : IStudentsLinkService
    {
        private readonly ICommonLinkService _commonLinkService;

        public StudentsLinkService(ICommonLinkService commonLinkService)
        {
            _commonLinkService = commonLinkService;
        }

        public void AddSelfLink(NewStudent user)
        {
            user.AddLink(GetSelfLink(user));
        }

        public void AddTutorLink(NewStudent user)
        {
            user.AddLink(GetTutorLink(user));
        }

        private Link GetTutorLink(NewStudent s)
        {
            return _commonLinkService.GetLink(
                String.Format("tutors/{0}", s.TutorId), "tutor", HttpMethod.Get);
        }

        public virtual Link GetSelfLink(NewStudent user)
        {
            var pathFragment = String.Format("students/{0}", user.StudentId);
            var link = _commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.Self, HttpMethod.Get);
            return link;
        }
    }
}