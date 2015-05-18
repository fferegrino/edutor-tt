using Edutor.Web.Api.InquiryProcessing;
using Edutor.Web.Api.MaintenanceProcessing;
using Edutor.Web.Api.Models.NewModels;
using Edutor.Web.Api.Models.ReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Edutor.Web.Api.Controllers
{
    [Edutor.Web.Common.UnitOfWorkActionFilter]
    public class QuestionsController : ApiController
    {
        private readonly IPostQuestionMaintenanceProcessor _postQuestion;
        private readonly IGetQuestionsInquiryProcessor _getQuestions;
        public QuestionsController(IPostQuestionMaintenanceProcessor postQuestion,
            IGetQuestionsInquiryProcessor getQuestions)
        {
            _postQuestion = postQuestion;
            _getQuestions = getQuestions;
        }

        /// <summary>
        /// Obtiene la pregunta indicada
        /// </summary>
        /// <param name="questionId">El id de la notificación deseada</param>
        /// <returns></returns>
        [HttpGet]
        [Route("questions/{questionId:int}")]
        public Question GetQuestion(int questionId)
        {
            return _getQuestions.GetQuestion(questionId);
        }

        /// <summary>
        /// Agrega una nueva pregunta al sistema
        /// </summary>
        /// <param name="newQuestion">La nueva pregunta a agregar</param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult AddQuestion(NewQuestion newQuestion)
        {
            var ret = _postQuestion.AddQuestion(newQuestion);
            var result = new ModelPostedActionResult<Question>(Request, ret);
            return result;
        }
    }
}
