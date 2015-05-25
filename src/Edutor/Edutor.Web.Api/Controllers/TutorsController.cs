using Edutor.Common;
using Edutor.Common.Extensions;
using Edutor.Web.Api.InquiryProcessing;
using Edutor.Web.Api.MaintenanceProcessing;
using Edutor.Web.Api.Models;
using Edutor.Web.Api.Models.NewModels;
using Edutor.Web.Api.Models.ReturnTypes;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Linq;
using System.Security.Claims;
using Edutor.Web.Common.Exceptions;
using Edutor.Web.Api.Models.ModModels;
using System.Net;
using Edutor.Web.Common;

namespace Edutor.Web.Api.Controllers
{
    /// <summary>
    /// Conjunto de extremos REST que permiten operar con los servicios de creación y manipulación de usuarios tutores que ofrece la plataforma
    /// </summary>
    [UnitOfWorkActionFilter]
    public class TutorsController : ApiController
    {
        private readonly IPostTutorMaintenanceProcessor _addUsers;
        private readonly IGetTutorsInquiryProcessor _getUsers;
        private readonly IGetStudentsInquiryProcessor _getStudents;
        private readonly IGetConversationsInquiryProcessor _getConversations;
        private readonly IDeleteUserMaintenanceProcessing _deleteTutors;
        private readonly IPagedDataRequestFactory _pagedDataRequestFactory;
        private readonly IPatchTutorMaintenanceProcessor _patchTutors;


        public TutorsController(IPostTutorMaintenanceProcessor addUserQueryProcessor,
            IGetTutorsInquiryProcessor getQueryProcessor,
            IPatchTutorMaintenanceProcessor patchTutors,
            IDeleteUserMaintenanceProcessing deleteTutors,
            IGetConversationsInquiryProcessor getConversations,
            IGetStudentsInquiryProcessor getStudentsQueryProcessor,
            IPagedDataRequestFactory pagedDataRequestFactory)
        {
            _deleteTutors = deleteTutors;
            _patchTutors = patchTutors;
            _addUsers = addUserQueryProcessor;
            _getUsers = getQueryProcessor;
            _getStudents = getStudentsQueryProcessor;
            _pagedDataRequestFactory = pagedDataRequestFactory;
            _getConversations = getConversations;
        }

        /// <summary>
        /// Agrega un nuevo tutor al sistema
        /// </summary>
        /// <param name="newTutor">El nuevo tutor a ingresar</param>
        /// <returns></returns>
        [HttpPost]
        [Route("tutors")]
        [Authorize(Roles = Constants.RoleNames.Administrator)]
        [ResponseType(typeof(Tutor))]
        public IHttpActionResult AddTutor(NewTutor newTutor)
        {
            var user = _addUsers.AddUser(newTutor);
            var result = new ModelPostedActionResult<Tutor>(Request, user);
            return result;
        }

        /// <summary>
        /// Modifica el tutor de acuerdo a lo enviado en el parámetro <paramref name="tutor"/>
        /// </summary>
        /// <param name="tutor"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("tutors")]
        [Authorize(Roles = Constants.RoleNames.Administrator)]
        [ResponseType(typeof(Tutor))]
        public IHttpActionResult UpdateGroup(ModifiableTutor tutor)
        {
            var m = _patchTutors.UpdateTutor(tutor);
            return new ModelUpdatedActionResult<Tutor>(Request, m);
        }

        /// <summary>
        /// Obtiene todos los tutores registrados en el sistema
        /// </summary>
        /// <returns>Una respuesta paginada de todos los tutores en el sistema</returns>
        [HttpGet]
        [Route("tutors")]
        [Authorize(Roles = Constants.RoleNames.Administrator)]
        [ResponseType(typeof(PagedDataResponse<Tutor>))]
        public PagedDataResponse<Tutor> GetAllPagedTutors()
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var s = _getUsers.GetAllTutors(request);
            return s;
        }

        /// <summary>
        /// Elimina al tutor indicado del sistema siempre y cuando no existan conflictos, que tengan estudiantes vinculados es un ejemplo.
        /// </summary>
        /// <param name="tutorId">El identificador de el tutor a eliminar</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("tutors/{tutorId:int}")]
        [Authorize(Roles = Constants.RoleNames.Administrator)]
        //[ResponseType(type))]
        public IHttpActionResult DeleteTutor(int tutorId)
        {
            _deleteTutors.Delete(tutorId);
            return new ModelDeletedActionResult(Request);
        }


        /// <summary>
        /// Obtiene el tutor indicado
        /// </summary>
        /// <param name="tutorId">El identificador único del tutor a recuperar</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(Tutor))]
        [Route("tutors/{tutorId:int}")]
        public Tutor GetTutor(int tutorId)
        {
            var s = _getUsers.GetTutor(tutorId);
            return s;
        }

        /// <summary>
        /// Obtiene el tutor indicado
        /// </summary>
        /// <param name="curp">La Clave Única de Registro de Población del tutor</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(Tutor))]
        [Route("tutors/{curp:regex(" + Constants.CommonRoutingDefinitions.CurpRegex + ")}")]
        public Tutor GetTutor(string curp)
        {
            var s = _getUsers.GetTutor(curp);
            return s;
        }


        /// <summary>
        /// Obtiene todos los estudiantes asignados al tutor asignado
        /// </summary>
        /// <param name="tutorId">El grupo del que se desea conocer los profesores</param>
        /// <returns>Una lista con los profesores asignados a cada grupo</returns>
        [HttpGet]
        [Route("tutors/{tutorId:int}/students")]
        [ResponseType(typeof(PagedDataResponse<Student>))]
        [Authorize(Roles = Edutor.Common.Constants.RoleNames.All)]
        public PagedDataResponse<Student> GetPagedStudentsForTutor(int tutorId)
        {
            var identity = ((System.Security.Claims.ClaimsIdentity)User.Identity).Claims;
            var role = User.Identity.GetClaim(ClaimTypes.Role);
            var isTutor = role.Equals(Edutor.Common.Constants.RoleNames.Tutor);
            if (isTutor)
            {
                if (User.Identity.GetIdClaim(Edutor.Common.Constants.CustomClaimTypes.TutorId) != tutorId)
                {
                    throw new CustomAuthorizationException("Como tutor solo puedes acceder a tus los estudiantes que están registrados a tu nombre");
                }
            }

            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var r = _getStudents.GetStudentsForTutor(tutorId, request, isTutor);
            return r;
        }


        /// <summary>
        /// Obtiene una lista de las conversaciones creadas por el usuario escolar
        /// </summary>
        /// <param name="tutorId">El id del tutor del que se desea conocer sus conversaciones</param>
        /// <returns>Una lista con las preguntas creadas por el usuario escolar</returns>
        [HttpGet]
        [Route("tutors/{tutorId:int}/conversations")]
        public PagedDataResponse<Conversation> GetPagedConversationsForTutor(int tutorId)
        {

            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var r = _getConversations.GetMessagesForUser(tutorId, request);
            return r;
        }



    }
}
