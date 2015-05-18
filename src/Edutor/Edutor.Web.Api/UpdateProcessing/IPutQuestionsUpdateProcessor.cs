using Edutor.Common.TypeMapping;
using Edutor.Data.Entities;
using Edutor.Data.QueryProcessors;
using Edutor.Web.Api.Models.NewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.UpdateProcessing
{
    public interface IPutQuestionsUpdateProcessor
    {
        void AnswerQuestion(NewAnswer newRsvp);
    }

    public class PutQuestionsUpdateProcessor : IPutQuestionsUpdateProcessor
    {
        private readonly IAutoMapper _mapper;
        private readonly IUpdateQuestionsQueryProcessor _updateQuestions;

        public PutQuestionsUpdateProcessor(IUpdateQuestionsQueryProcessor updateEvents,
            IAutoMapper mapper)
        {
            _updateQuestions = updateEvents;
            _mapper = mapper;
        }


        public void AnswerQuestion(NewAnswer newRsvp)
        {
            _updateQuestions.AnswerQuestion(_mapper.Map<Answer>(newRsvp));
        }
    }
}
