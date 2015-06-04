using Edutor.Common;
using Edutor.Data.QueryProcessors;
using Edutor.Web.Api.InquiryProcessing;
using Edutor.Web.Api.MaintenanceProcessing;
using Edutor.Web.Api.Models;
using Edutor.Web.Api.Models.ModModels;
using Edutor.Web.Api.Models.NewModels;
using Edutor.Web.Api.Models.ReturnTypes;
//using Edutor.Web.Api.QueryProcessing;
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
    /// Conjunto de extremos REST que permiten operar con los servicios de creación y manipulación de usuarios escolares que ofrece la plataforma
    /// </summary>
    [UnitOfWorkActionFilter]
    public class SchoolUsersController : ApiController
    {
        private readonly IPostSchoolUserMaintenanceProcessor _addUser;
        private readonly IGetSchoolUsersInquiryProcessor _getSchoolUser;
        private readonly IGetGroupsInquiryProcessor _getGroupsProcessor;
        private readonly IGetNotificationsInquiryProcessor _getNotifications;
        private readonly IGetConversationsInquiryProcessor _getConversations;
        private readonly IGetEventsInquiryProcessor _getEvents;
        private readonly IGetTutorsInquiryProcessor _getTutors;
        private readonly IDeleteUserMaintenanceProcessing _deleteSchoolUsers;
        private readonly IPatchSchoolUserMaintenanceProcessor _patchUsers;
        private readonly IGetQuestionsInquiryProcessor _getQuestions;
        private readonly IPagedDataRequestFactory _pagedDataRequestFactory;

        public SchoolUsersController(IPostSchoolUserMaintenanceProcessor addUserQueryProcessor,
            IGetSchoolUsersInquiryProcessor getQueryProcessor,
            IPagedDataRequestFactory pagedDataRequestFactory,
            IGetTutorsInquiryProcessor getTutors,
            IGetNotificationsInquiryProcessor getNotifications,
            IPatchSchoolUserMaintenanceProcessor patchUsers,
            IDeleteUserMaintenanceProcessing deleteTutors,
            IGetGroupsInquiryProcessor getGroupsProcessor,
            IGetConversationsInquiryProcessor getConversations,
            IGetEventsInquiryProcessor getEvents,
            IGetQuestionsInquiryProcessor getQuestions)
        {
            _getTutors = getTutors;
            _deleteSchoolUsers = deleteTutors;
            _patchUsers = patchUsers;
            _getSchoolUser = getQueryProcessor;
            _addUser = addUserQueryProcessor;
            _pagedDataRequestFactory = pagedDataRequestFactory;
            _getGroupsProcessor = getGroupsProcessor;
            _getNotifications = getNotifications;
            _getEvents = getEvents;
            _getConversations = getConversations;
            _getQuestions = getQuestions;
        }

        /// <summary>
        /// Obtiene una lista paginada de todos los usuarios escolares registrados en el sistema.
        /// Este extremo es accesible únicamente por usuarios administradores.
        /// </summary>
        /// <returns>Una lista paginada de todos los usuarios escolares que existen en el sistema.</returns>
        [HttpGet]
        [Route("schoolusers")]
        [Authorize(Roles = Constants.RoleNames.Administrator)]
        public PagedDataResponse<SchoolUser> GetSchoolUsers()
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var tasks = _getSchoolUser.GetAllSchoolUsers(request);
            return tasks;
        }


        /// <summary>
        /// Obtiene el grupo indicado por su identificador único, 
        /// Un usuario administrador podrá acceder a la información de todos los usuarios escolares, 
        /// mientras que cualquier otro usuario podrá acceder únicamente a su información.
        /// </summary>
        /// <param name="schoolUserId">El identificador único del usuario escolar a obtener.</param>
        /// <returns>El usuario escolar deseado.</returns>
        [HttpGet]
        [Route("schoolusers/{schoolUserId:int}")]
        [Authorize(Roles = Constants.RoleNames.All)]
        public SchoolUser GetSchoolUser(int schoolUserId)
        {
            var s = _getSchoolUser.GetSchoolUser(schoolUserId);
            return s;
        }

        /// <summary>
        /// Obtiene el usuario escolar indicado realizando la búsqueda mediante la CURP
        /// </summary>
        /// <param name="curp">La Clave Única de Registro de Población del usuario escolar</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(SchoolUser))]
        [Route("schoolusers/{curp:regex(" + Constants.CommonRoutingDefinitions.CurpRegex + ")}")]
        [Authorize(Roles = Constants.RoleNames.All)]
        public SchoolUser GetSchoolUser(string curp)
        {
            var s = _getSchoolUser.GetSchoolUser(curp);
            return s;
        }



        /// <summary>
        /// Obtiene los grupos asignados al usuario escolar indicado
        /// </summary>
        /// <param name="schoolUserId">El id del usuario escolar</param>
        /// <returns></returns>
        [HttpGet]
        [Route("schoolusers/{schoolUserId:int}/groups")]
        [Authorize(Roles = Constants.RoleNames.SchoolUser)]
        public PagedDataResponse<Group> GetGroupsForSchoolUser(int schoolUserId)
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var tasks = _getGroupsProcessor.GetGroupsForSchoolUser(schoolUserId, request);
            return tasks;
        }


        /// <summary>
        /// Obtiene una lista de las notificaciones creadas por el usuario escolar
        /// </summary>
        /// <param name="schoolUserid">El id del usuario escolar del que se desea conocer sus notificaciones</param>
        /// <returns>Una lista con las notificaciones creadas por el usuario escolar</returns>
        [HttpGet]
        [Route("schoolusers/{schoolUserId:int}/notifications")]
        [Authorize(Roles = Constants.RoleNames.SchoolUser)]
        public PagedDataResponse<Notification> GetNotificationsForSchoolUser(int schoolUserid)
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var r = _getNotifications.GetNotificationsForSchoolUser(schoolUserid, request);
            return r;
        }

        /// <summary>
        /// Obtiene una lista de los eventos creados por el usuario escolar
        /// </summary>
        /// <param name="schoolUserid">El id del usuario escolar del que se desea conocer sus eventos</param>
        /// <returns>Una lista con los eventos creados por el usuario escolar</returns>
        [HttpGet]
        [Route("schoolusers/{schoolUserId:int}/events")]
        [Authorize(Roles = Constants.RoleNames.SchoolUser)]
        public PagedDataResponse<Event> GetEventsForSchoolUser(int schoolUserid)
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var r = _getEvents.GetEventsForSchoolUser(schoolUserid, request);
            return r;
        }

        /// <summary>
        /// Obtiene una lista de las preguntas creadas por el usuario escolar
        /// </summary>
        /// <param name="schoolUserid">El id del usuario escolar del que se desea conocer sus preguntas</param>
        /// <returns>Una lista con las preguntas creadas por el usuario escolar</returns>
        [HttpGet]
        [Route("schoolusers/{schoolUserId:int}/questions")]
        [Authorize(Roles = Constants.RoleNames.SchoolUser)]
        public PagedDataResponse<Question> GetQuestionsForSchoolUser(int schoolUserid)
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var r = _getQuestions.GetQuestionsForSchoolUser(schoolUserid, request);
            return r;
        }

        /// <summary>
        /// Obtiene una lista de las conversaciones creadas por el usuario escolar
        /// </summary>
        /// <param name="schoolUserid">El id del usuario escolar del que se desea conocer sus conversaciones</param>
        /// <returns>Una lista con las preguntas creadas por el usuario escolar</returns>
        [HttpGet]
        [Route("schoolusers/{schoolUserId:int}/conversations")]
        [Authorize(Roles = Constants.RoleNames.SchoolUser)]
        public PagedDataResponse<Conversation> GetConversationsForSchoolUser(int schoolUserid)
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var r = _getConversations.GetMessagesForUser(schoolUserid, request);
            return r;
        }

        /// <summary>
        /// Obtiene una lista de los tutores relacionados con el usuario escolar
        /// </summary>
        /// <param name="schoolUserid">El id del usuario escolar del que se desea conocer sus tutores relacionados</param>
        /// <returns>Una lista con las preguntas creadas por el usuario escolar</returns>
        [HttpGet]
        [Route("schoolusers/{schoolUserId:int}/tutors")]
        [Authorize(Roles = Constants.RoleNames.SchoolUser)]
        public PagedDataResponse<Tutor> GetTutorsForSchoolUsers(int schoolUserid)
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var r = _getTutors.GetTutorsForTeacher(schoolUserid, request);
            return r;
        }

        /// <summary>
        /// Agrega usuario escolar al sistema con los valores establecidos en el cuerpo de la peiticón
        /// </summary>
        /// <remarks>Agrega un nuevo usuario escolar al sistem</remarks>
        /// <param name="newUser">El nuevo usuario a agregar</param>
        /// <returns>Información delevante al usuario escoar creado</returns>
        [HttpPost]
        [ResponseType(typeof(SchoolUser))]
        [Route("schoolusers")]
        [Authorize(Roles = Constants.RoleNames.Administrator)]
        public IHttpActionResult AddSchoolUser(NewSchoolUser newUser)
        {
            var user = _addUser.AddUser(newUser);
            var result = new ModelPostedActionResult<SchoolUser>(Request, user);
            return result;
        }

        /// <summary>
        /// Modifica el usuario escolar de acuerdo a lo enviado en el parámetro <paramref name="schoolUser"/>
        /// </summary>
        /// <param name="schoolUser"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("schoolusers")]
        [Authorize(Roles = Constants.RoleNames.Administrator)]
        [ResponseType(typeof(SchoolUser))]
        public IHttpActionResult UpdateGroup(ModifiableSchoolUser schoolUser)
        {
            var m = _patchUsers.UpdateSchoolUser(schoolUser);
            return new ModelUpdatedActionResult<SchoolUser>(Request, m);
        }

        /// <summary>
        /// Elimina al usuario indicado del sistema siempre y cuando no existan conflictos
        /// </summary>
        /// <param name="schoolUserId">El identificador de el usuario a eliminar</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("schoolusers/{schoolUserId:int}")]
        [Authorize(Roles = Constants.RoleNames.Administrator)]
        //[ResponseType(type))]
        public IHttpActionResult DeleteTutor(int schoolUserId)
        {
            _deleteSchoolUsers.Delete(schoolUserId);
            return new ModelDeletedActionResult(Request);
        }
    }
}
