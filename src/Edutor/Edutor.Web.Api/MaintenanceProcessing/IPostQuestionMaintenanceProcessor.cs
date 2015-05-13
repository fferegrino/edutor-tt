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

namespace Edutor.Web.Api.MaintenanceProcessing
{
    public interface IPostQuestionMaintenanceProcessor
    {
        Ret.Question AddQuestion(NewQuestion q);
    }

    public class PostQuestionMaintenanceProcessor : IPostQuestionMaintenanceProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly IAddQuestionQueryProcessor _addQuestionQP;
        private readonly IAddPossibleAnswerQueryProcessor _addInvitationQP;
        private readonly IAddAnswerQueryProcessor _addAns;
        private readonly IEventsLinkService _linkServices;

        public PostQuestionMaintenanceProcessor(IAutoMapper autoMapper,
            IAddQuestionQueryProcessor addUserQueryProcessor,
            IAddPossibleAnswerQueryProcessor addInvitationsQueryProcessor,
            IAddAnswerQueryProcessor addAns,
            IEventsLinkService linkServices)
        {
            _autoMapper = autoMapper;
            _addQuestionQP = addUserQueryProcessor;
            _addAns = addAns;
            _linkServices = linkServices;
            _addInvitationQP = addInvitationsQueryProcessor;
        }

        public Ret.Question AddQuestion(NewQuestion q)
        {
            var eventEntity = _autoMapper.Map<Data.Entities.Question>(q);
            _addQuestionQP.AddQuestion(eventEntity);
            var ret = _autoMapper.Map<Ret.Question>(eventEntity);
            return ret;
        }

        //public Ret.Event AddEvent(NewEvent ev)
        //{

        //    var eventEntity = _autoMapper.Map<Data.Entities.Event>(ev);
        //    _addEventQueryProcessor.AddEvent(eventEntity);
        //    var ret = _autoMapper.Map<Ret.Event>(eventEntity);

        //    var students = eventEntity.Group.Students;
        //    //for (int i = 0; i < students.Count; i++)
        //    //{
        //    //    _addInvitationsQueryProcessor.AddInvitation(new Data.Entities.Invitation { Rsvp = null, EventId = eventEntity.EventId, StudentId = students[i].StudentId });
        //    //}

        //    var invitations = from s in students
        //                      select new Data.Entities.Invitation
        //                      {
        //                          Rsvp = null,
        //                          EventId = eventEntity.EventId,
        //                          StudentId = s.StudentId
        //                      };

        //    _addInvitationsQueryProcessor.AddInvitations(invitations.ToList());

        //    _linkServices.AddSelfLink(ret);

        //    return ret;
        //}
    }
}
