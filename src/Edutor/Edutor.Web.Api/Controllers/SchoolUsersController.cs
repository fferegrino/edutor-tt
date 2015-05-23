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
        private readonly IPostSchoolUserMaintenanceProcessor _addUserQueryProcessor;
        private readonly IGetSchoolUsersInquiryProcessor _getQueryProcessor;
        private readonly IGetGroupsInquiryProcessor _getGroupsProcessor;
        private readonly IGetNotificationsInquiryProcessor _getNotifications;
        private readonly IGetConversationsInquiryProcessor _getConversations;
        private readonly IGetEventsInquiryProcessor _getEvents;
        private readonly IPatchSchoolUserMaintenanceProcessor _patchUsers;
        private readonly IGetQuestionsInquiryProcessor _getQuestions;
        private readonly IPagedDataRequestFactory _pagedDataRequestFactory;

        public SchoolUsersController(IPostSchoolUserMaintenanceProcessor addUserQueryProcessor,
            IGetSchoolUsersInquiryProcessor getQueryProcessor,
            IPagedDataRequestFactory pagedDataRequestFactory,
            IGetNotificationsInquiryProcessor getNotifications,
            IPatchSchoolUserMaintenanceProcessor patchUsers,
            IGetGroupsInquiryProcessor getGroupsProcessor,
            IGetConversationsInquiryProcessor getConversations,
            IGetEventsInquiryProcessor getEvents,
            IGetQuestionsInquiryProcessor getQuestions)
        {
            _patchUsers = patchUsers;
            _getQueryProcessor = getQueryProcessor;
            _addUserQueryProcessor = addUserQueryProcessor;
            _pagedDataRequestFactory = pagedDataRequestFactory;
            _getGroupsProcessor = getGroupsProcessor;
            _getNotifications = getNotifications;
            _getEvents = getEvents;
            _getConversations = getConversations;
            _getQuestions = getQuestions;
        }

        /// <summary>
        /// Agrega usuario escolar
        /// </summary>
        /// <remarks>Agrega un nuevo usuario escolar al sistem</remarks>
        /// <param name="newUser">El nuevo usuario a agregar</param>
        /// <returns></returns>
        /// <response code="201">Usuario escolar creado</response>
        [HttpPost]
        [ResponseType(typeof(SchoolUser))]
        [Route("schoolusers")]
        public IHttpActionResult AddSchoolUser(NewSchoolUser newUser)
        {
            var user = _addUserQueryProcessor.AddUser(newUser);
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
        /// Recupera una lista paginada de usuarios escolares
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("schoolusers")]
        public PagedDataResponse<SchoolUser> GetSchoolUsers()
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var tasks = _getQueryProcessor.GetAllSchoolUsers(request);
            return tasks;
        }

        /// <summary>
        /// Obtiene el usuario escolar indicado
        /// </summary>
        /// <param name="schoolUserId">El id del usuario escolar</param>
        /// <returns></returns>
        [HttpGet]
        [Route("schoolusers/{schoolUserId:int}")]
        public SchoolUser GetSchoolUser(int schoolUserId)
        {
            var s = _getQueryProcessor.GetSchoolUser(schoolUserId);
            return s;
        }

        /// <summary>
        /// Obtiene el usuario escolar indicado
        /// </summary>
        /// <param name="curp">La Clave Única de Registro de Población del usuario escolar</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(SchoolUser))]
        [Route("schoolusers/{curp:regex(" + Constants.CommonRoutingDefinitions.CurpRegex + ")}")]
        public SchoolUser GetSchoolUser(string curp)
        {
            var s = _getQueryProcessor.GetSchoolUser(curp);
            return s;
        }


        /// <summary>
        /// Obtiene los grupos asignados al usuario escolar indicado
        /// </summary>
        /// <param name="schoolUserId">El id del usuario escolar</param>
        /// <returns></returns>
        [HttpGet]
        [Route("schoolusers/{schoolUserId:int}/groups")]
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
        public PagedDataResponse<Conversation> GetConversationsForSchoolUser(int schoolUserid)
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var r = _getConversations.GetMessagesForUser(schoolUserid, request);
            return r;
        }
    }
}
