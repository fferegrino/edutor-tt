using Edutor.Common;
using Edutor.Web.Api.InquiryProcessing;
using Edutor.Web.Api.MaintenanceProcessing;
using Edutor.Web.Api.Models;
using Edutor.Web.Api.Models.NewModels;
using Edutor.Web.Api.Models.ReturnTypes;
using Edutor.Web.Api.UpdateProcessing;
using Edutor.Web.Common;
using Edutor.Web.Common.Filters;
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
        /// Regresa la pregunta solicitada mediante la URL
        /// </summary>
        /// <param name="questionId">El identificador único de la notificación deseada</param>
        /// <returns></returns>
        [Route("questions/{questionId:int}")]
        [HttpGet]
        [Authorize(Roles = Constants.RoleNames.All)]
        public Question GetQuestion(int questionId)
        {
            return _getQuestions.GetQuestion(questionId);
        }

        /// <summary>
        /// Regresa una lista paginada con las respuestas a la pregunta especificada
        /// </summary>
        /// <param name="questionId">El identificador único de la pregunta deseada</param>
        /// <returns>Una lista paginada con las respuestas a la pregunta especificada</returns>
        [HttpGet]
        [Route("questions/{questionId:int}/answers")]
        [ResponseType(typeof(PagedDataResponse<StudentAnswer>))]
        [Authorize(Roles = Constants.RoleNames.SchoolUser)]
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
        [Authorize(Roles = Constants.RoleNames.All)]
        public StudentAnswer GetAnswerers(int questionId, int studentId)
        {
            var r = _getStudents.GetStudentsForQuestion(questionId,studentId);
            return r;
        }

        /// <summary>
        /// Agrega una nueva pregunta al sistema de acuerdo a la información enviáda en el cuerpo de la petición
        /// </summary>
        /// <param name="question">La nueva pregunta a agregar</param>
        /// <returns></returns>
        [Route("questions")]
        [HttpPost]
        [ResponseType(typeof(Question))]
        [Authorize(Roles = Constants.RoleNames.SchoolUser)]
        [ValidationActionFilter]
        public IHttpActionResult AddQuestion(NewQuestion question)
        {
            var ret = _postQuestion.AddQuestion(question);
            // Genera la respuesta con su correspondiente código de estatus HTTP
            var result = new ModelPostedActionResult<Question>(Request, ret);
            return result;
        }
        
        /// <summary>
        /// Responde a la pregunta con la respuesta seleccionada
        /// </summary>
        /// <param name="answer">La respuesta a la pregunta</param>
        /// <param name="questionId">El identificador único de la pregunta deseada</param>
        /// <param name="studentId">El identificador único del estudiante a nombre de quien se resuelve la preguntta</param>
        /// <returns></returns>
        [HttpPut]
        [Route("questions/{questionId:int}/answers/{studentId}")]
        [Authorize(Roles = Constants.RoleNames.Tutor)]
        public IHttpActionResult AnswerQuestion(NewAnswer answer, int questionId, int studentId)
        {
            answer.QuestionId = questionId;
            answer.StudentId = studentId;
            _updateQuestion.AnswerQuestion(answer);
            return new ModelDeletedActionResult(Request);
        }

    }
}
