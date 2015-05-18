using Edutor.Web.Api.InquiryProcessing;
using Edutor.Web.Api.MaintenanceProcessing;
using Edutor.Web.Api.Models;
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
        private readonly IGetStudentsInquiryProcessor _getStudents;
        private readonly IPagedDataRequestFactory _pagedDataRequestFactory;

        public QuestionsController(IPostQuestionMaintenanceProcessor postQuestion,
            IGetQuestionsInquiryProcessor getQuestions,
            IGetStudentsInquiryProcessor getStudents,
            IPagedDataRequestFactory pagedDataRequestFactory)
        {
            _postQuestion = postQuestion;
            _getQuestions = getQuestions;
            _getStudents = getStudents;
            _pagedDataRequestFactory = pagedDataRequestFactory;
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
        /// Obtiene las respuestas a la pregunta especificada
        /// </summary>
        /// <param name="questionId">El id de la pregunta deseada</param>
        /// <returns></returns>
        [HttpGet]
        [Route("questions/{questionId:int}/answers")]
        [ResponseType(typeof(PagedDataInquiryResponse<StudentAnswer>))]
        public PagedDataInquiryResponse<StudentAnswer> GetAnswerers(int questionId)
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var r = _getStudents.GetStudentsForQuestion(questionId, request);
            return r;
        }

        /// <summary>
        /// Obtiene la respuesta escogida por este estudiante
        /// </summary>
        /// <param name="questionId">El id de la pregunta deseada</param>
        /// <param name="studentId">El id del estudiante</param>
        /// <returns></returns>
        [HttpGet]
        [Route("questions/{questionId:int}/answers/{studentId}")]
        [ResponseType(typeof(StudentAnswer))]
        public StudentAnswer GetAnswerers(int questionId, int studentId)
        {
            var r = _getStudents.GetStudentsForQuestion(questionId,studentId);
            return r;
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
