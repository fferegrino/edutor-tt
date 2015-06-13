using Edutor.Common.TypeMapping;
using Edutor.Data.QueryProcessors;
using Edutor.Web.Api.LinkServices;
using Edutor.Web.Api.Models.NewModels;
using Ret = Edutor.Web.Api.Models.ReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edutor.Common.Security;
using Edutor.Common;

namespace Edutor.Web.Api.MaintenanceProcessing
{
    public interface IPostEventMaintenanceProcessor
    {
        Ret.Event AddEvent(NewEvent ev);
    }

    public class PostEventMaintenanceProcessor : IPostEventMaintenanceProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly IAddEventQueryProcessor _addEventQueryProcessor;
        private readonly IAddInvitationQueryProcessor _addInvitationsQueryProcessor;
        private readonly IEventsLinkService _linkServices;
        private readonly IWebUserSession _user;
        private readonly IGetStudentsQueryProcessor _getStudents;

        public PostEventMaintenanceProcessor(IAutoMapper autoMapper, 
            IAddEventQueryProcessor addUserQueryProcessor, 
            IAddInvitationQueryProcessor addInvitationsQueryProcessor, 
            IEventsLinkService linkServices,
            IWebUserSession user,
            IGetStudentsQueryProcessor getStudents)
        {
            _autoMapper = autoMapper;
            _addEventQueryProcessor = addUserQueryProcessor;
            _linkServices = linkServices;
            _addInvitationsQueryProcessor = addInvitationsQueryProcessor;
            _user = user;
            _getStudents = getStudents;
        }


        public Ret.Event AddEvent(NewEvent ev)
        {

            var eventEntity = _autoMapper.Map<Data.Entities.Event>(ev);
            _addEventQueryProcessor.AddEvent(eventEntity);
            var ret = _autoMapper.Map<Ret.Event>(eventEntity);

            IList<Data.Entities.Student> students = null;
            if(_user.IsInRole(Constants.RoleNames.Administrator))
            {
                students = _getStudents.GetAllStudentsBrute();
            }
            else
            {
                students = eventEntity.Group.Students;
            }

            var invitations = from s in students
                              select new Data.Entities.Invitation
                              {
                                  Rsvp = null,
                                  EventId = eventEntity.EventId,
                                  StudentId = s.StudentId
                              };

            _addInvitationsQueryProcessor.AddInvitations(invitations.ToList());

            _linkServices.AddAllLinks(ret);

            return ret;
        }
    }
}
