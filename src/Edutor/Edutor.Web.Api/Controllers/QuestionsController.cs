using Edutor.Web.Api.InquiryProcessing;
using Edutor.Web.Api.MaintenanceProcessing;
using Edutor.Web.Api.Models;
using Edutor.Web.Api.Models.NewModels;
using Edutor.Web.Api.Models.ReturnTypes;
using Edutor.Web.Api.UpdateProcessing;
using Edutor.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Edutor.Web.Api.Controllers
{
    /// <summary>
    /// Conjunto de extremos REST que permiten operar con los servicios de creación y manipulación de preguntas que ofrece la plataforma
    /// </summary>
    [UnitOfWorkActionFilter]
    public class QuestionsController : ApiController
    {
        private readonly IPostQuestionMaintenanceProcessor _postQuestion;
        private readonly IPutQuestionsUpdateProcessor _updateQuestion;
        private readonly IGetQuestionsInquiryProcessor _getQuestions;
        private readonly IGetStudentsInquiryProcessor _getStudents;
        private readonly IPagedDataRequestFactory _pagedDataRequestFactory;

        public QuestionsController(IPostQuestionMaintenanceProcessor postQuestion,
            IGetQuestionsInquiryProcessor getQuestions,
            IGetStudentsInquiryProcessor getStudents,
            IPutQuestionsUpdateProcessor updateQuestion,
            IPagedDataRequestFactory pagedDataRequestFactory)
        {
            _postQuestion = postQuestion;
            _getQuestions = getQuestions;
            _getStudents = getStudents;
            _pagedDataRequestFactory = pagedDataRequestFactory;
            _updateQuestion = updateQuestion;
        }

        /// <summary>
        /// Agrega una nueva pregunta al sistema
        /// </summary>
        /// <param name="newQuestion">La nueva pregunta a agregar</param>
        /// <returns></returns>
        [Route("questions")]
        [HttpPost]
        [ResponseType(typeof(Question))]
        public IHttpActionResult AddQuestion(NewQuestion newQuestion)
        {
            var ret = _postQuestion.AddQuestion(newQuestion);
            // Genera la respuesta con su correspondiente código de estatus HTTP
            var result = new ModelPostedActionResult<Question>(Request, ret);
            return result;
        }

        /// <summary>
        /// Obtiene la pregunta indicada
        /// </summary>
        /// <param name="questionId">El identificador único de la notificación deseada</param>
        /// <returns></returns>
        [Route("questions/{questionId:int}")]
        [HttpGet]
        public Question GetQuestion(int questionId)
        {
            return _getQuestions.GetQuestion(questionId);
        }

        /// <summary>
        /// Obtiene las respuestas a la pregunta especificada
        /// </summary>
        /// <param name="questionId">El identificador único de la pregunta deseada</param>
        /// <returns></returns>
        [HttpGet]
        [Route("questions/{questionId:int}/answers")]
        [ResponseType(typeof(PagedDataResponse<StudentAnswer>))]
        public PagedDataResponse<StudentAnswer> GetAnswerers(int questionId)
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var r = _getStudents.GetStudentsForQuestion(questionId, request);
            return r;
        }

        /// <summary>
        /// Obtiene la respuesta escogida por este estudiante
        /// </summary>
        /// <param name="questionId">El identificador único de la pregunta deseada</param>
        /// <param name="studentId">El identificador único del estudiante</param>
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
        /// Responde a la pregunta con la respuesta seleccionada
        /// </summary>
        /// <param name="newAnswer"></param>
        /// <param name="questionId">El identificador único de la pregunta deseada</param>
        /// <param name="studentId">El identificador único del estudiante</param>
        /// <returns></returns>
        [HttpPut]
        [Route("questions/{questionId:int}/answers/{studentId}")]
        [ResponseType(typeof(int))]
        public int GetAnswerers(NewAnswer newAnswer, int questionId, int studentId)
        {
            newAnswer.QuestionId = questionId;
            newAnswer.StudentId = studentId;
            _updateQuestion.AnswerQuestion(newAnswer);
            return 0;
        }

    }
}
