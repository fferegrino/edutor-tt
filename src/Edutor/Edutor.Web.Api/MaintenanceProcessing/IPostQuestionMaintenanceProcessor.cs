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
        private readonly IAddPossibleAnswerQueryProcessor _addPossibleAnswerQP;
        private readonly IAddAnswerQueryProcessor _addAns;
        private readonly IQuestionsLinkService _linkServices;

        public PostQuestionMaintenanceProcessor(IAutoMapper autoMapper,
            IAddQuestionQueryProcessor addUserQueryProcessor,
            IAddPossibleAnswerQueryProcessor addInvitationsQueryProcessor,
            IAddAnswerQueryProcessor addAns,
            IQuestionsLinkService linkServices)
        {
            _autoMapper = autoMapper;
            _addQuestionQP = addUserQueryProcessor;
            _addAns = addAns;
            _linkServices = linkServices;
            _addPossibleAnswerQP = addInvitationsQueryProcessor;
        }

        public Ret.Question AddQuestion(NewQuestion q)
        {
            var eventEntity = _autoMapper.Map<Data.Entities.Question>(q);
            _addQuestionQP.AddQuestion(eventEntity);

            var students = eventEntity.Group.Students;

            int i = 0;
            var possibleAnswers = from popssibleAnswerText in q.PossibleAnswers
                                  select new Data.Entities.PossibleAnswer
                                  {
                                      Text = popssibleAnswerText,
                                      QuestionId = eventEntity.QuestionId,
                                      PossibleAnswerId = i++,
                                  };
            var lst = possibleAnswers.ToList();
            _addPossibleAnswerQP.AddPossibleAnswers(lst);
            eventEntity.PossibleAnswers = lst;
            var ret = _autoMapper.Map<Ret.Question>(eventEntity);

            var answersStudents = from student in students
                                  select new Data.Entities.Answer
                                  {
                                      ActualAnswerId = null,
                                      QuestionId = eventEntity.QuestionId,
                                      StudentId = student.StudentId
                                  };

            _addAns.AddAnswers(answersStudents.ToList());
            
            _linkServices.AddAllLinks(ret);

            return ret;
        }

    }
}
