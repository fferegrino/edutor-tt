using Edutor.Web.Api.MaintenanceProcessing;
using Edutor.Web.Api.Models.NewModels;
using Edutor.Web.Api.Models.ReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Edutor.Web.Api.Controllers
{
    [Edutor.Web.Common.UnitOfWorkActionFilter]
    public class QuestionsController : ApiController
    {
        private readonly IPostQuestionMaintenanceProcessor _postQuestion;
        public QuestionsController(IPostQuestionMaintenanceProcessor postQuestion)
        {
            _postQuestion = postQuestion;
        }

        [HttpPost]
        public IHttpActionResult AddQuestion(NewQuestion q)
        {
            var ret = _postQuestion.AddQuestion(q);
            var result = new ModelPostedActionResult<Question>(Request, ret);
            return result;
        }
    }
}
