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
    public interface IStudentsLinkService
    {
        void AddSelfLink(Student user);
        void AddTutorLink(Student user);
    }

    public class StudentsLinkService : IStudentsLinkService
    {
        private readonly ICommonLinkService _commonLinkService;

        public StudentsLinkService(ICommonLinkService commonLinkService)
        {
            _commonLinkService = commonLinkService;
        }

        public void AddSelfLink(Student user)
        {
            user.AddLink(GetSelfLink(user));
        }

        public void AddTutorLink(Student user)
        {
            user.AddLink(GetTutorLink(user));
        }

        private Link GetTutorLink(Student s)
        {
            return _commonLinkService.GetLink(
                String.Format("tutors/{0}", s.TutorId), "tutor", HttpMethod.Get);
        }

        public virtual Link GetSelfLink(Student user)
        {
            var pathFragment = String.Format("students/{0}", user.StudentId);
            var link = _commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.Self, HttpMethod.Get);
            return link;
        }
    }
}