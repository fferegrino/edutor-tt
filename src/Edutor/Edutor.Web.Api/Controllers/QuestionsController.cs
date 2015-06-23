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
    /// Las preguntas son otra forma de comunicación que ofrecen los extremos de Edutor,
    /// a través de ellos los usuarios escolares pueden crear preguntas y los tutores responderlas.
    /// Los extremos requieren de que el usuario que los utiliza esté autorizado.
    /// </summary>
    [UnitOfWorkActionFilter]
    public class QuestionsController : ApiController
    {
        private readonly IPostQuestionMaintenanceProcessor _postQuestion;
        private readonly IPutQuestionsUpdateProcessor _updateQuestion;
        private readonly IGetQuestionsInquiryProcessor _getQuestions;
        private readonly IGetStudentsInquiryProcessor _getStudents;
        private readonly IPagedDataRequestFactory _pagedDataRequestFactory;
        private readonly IDeleteInteracionsMaintenanceProcessor _deleteInteractions;

        public QuestionsController(IPostQuestionMaintenanceProcessor postQuestion,
            IGetQuestionsInquiryProcessor getQuestions,
            IGetStudentsInquiryProcessor getStudents,
            IPutQuestionsUpdateProcessor updateQuestion,
            IPagedDataRequestFactory pagedDataRequestFactory,
            IDeleteInteracionsMaintenanceProcessor deleteInteractions)
        {
            _deleteInteractions = deleteInteractions;
            _postQuestion = postQuestion;
            _getQuestions = getQuestions;
            _getStudents = getStudents;
            _pagedDataRequestFactory = pagedDataRequestFactory;
            _updateQuestion = updateQuestion;
        }


        /// <summary>
        /// Obtiene la pregunta indicada por su identificador único, 
        /// Un usuario administrador podrá acceder a la información de todas las preguntas, 
        /// mientras que cualquier otro usuario podrá acceder únicamente a las preguntas que creó o de las que es receptor.
        /// </summary>
        /// <param name="questionId">El identificador único de la pregunta a obtener.</param>
        /// <returns>Devuelve la pregunta deseada, en caso de que exista y el usuario tenga permiso para acceder a él.</returns>
        [Route("questions/{questionId:int}")]
        [HttpGet]
        [Authorize(Roles = Constants.RoleNames.All)]
        public Question GetQuestion(int questionId)
        {
            return _getQuestions.GetQuestion(questionId);
        }

        /// <summary>
        /// Obtiene una lista paginada con las respuestas a la pregunta, 
        /// cada respuesta consiste del identificador del estudiante que responde y 
        /// la respuesta elegida por el tutor del mismo.
        /// </summary>
        /// <param name="questionId">El identificador único de la pregunta de la que se desea obtener las respuestas.</param>
        /// <returns>Devuelve una lista paginada con las respuestas a la pregunta.</returns>
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
        /// Obtienen el la respuesta indicada, cada respuesta consiste del identificador del estudiante que responde y 
        /// la respuesta elegida por el tutor del mismo.
        /// </summary>
        /// <param name="questionId">El identificador único de la pregunta que se desea obtener.</param>
        /// <param name="studentId">El identificador único del estudiante del que se desea obtener la respuesta.</param>
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
        /// <returns>La pregunta agregada al sistema.</returns>
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
        /// <returns>Un código de estatus 204 (sin contenido) si la acción se realizó con éxito</returns>
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

        /// <summary>
        /// Elimina la pregunta del sistema, 
        /// las respuestas de los tutores también son eliminadas junto con la pregunta
        /// Esta acción solamente puede ser llevada a cabo por usuarios escolares.
        /// </summary>
        /// <param name="questionId">El identificador único de la pregunta a eliminar.</param>
        /// <returns>Un código de estatus (No Content) si es que la acción se concluyó correctamente.</returns>
        [HttpDelete]
        [Authorize(Roles = Constants.RoleNames.SchoolUser)]
        [Route("questions/{questionId:int}")]
        public IHttpActionResult DeleteEvent(int questionId)
        {
            _deleteInteractions.DeleteQuestion(questionId);
            return new ModelDeletedActionResult(Request);
        }

    }
}
