using Edutor.Data.QueryProcessors;
using Edutor.Web.Api.InquiryProcessing;
using Edutor.Web.Api.MaintenanceProcessing;
using Edutor.Web.Api.Models;
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
    [UnitOfWorkActionFilter]
    public class SchoolUsersController : ApiController
    {
        private readonly IPostSchoolUserMaintenanceProcessor _addUserQueryProcessor;
        private readonly IGetSchoolUsersInquiryProcessor _getQueryProcessor;
        private readonly IGetGroupsInquiryProcessor _getGroupsProcessor;
        private readonly IGetNotificationsInquiryProcessor _getNotifications;
        private readonly IPagedDataRequestFactory _pagedDataRequestFactory;
        private readonly IGetEventsInquiryProcessor _getEvents;
        private readonly IGetQuestionsInquiryProcessor _getQuestions;

        public SchoolUsersController(IPostSchoolUserMaintenanceProcessor addUserQueryProcessor,
            IGetSchoolUsersInquiryProcessor getQueryProcessor,
            IPagedDataRequestFactory pagedDataRequestFactory,
            IGetNotificationsInquiryProcessor getNotifications,
            IGetGroupsInquiryProcessor getGroupsProcessor, 
            IGetEventsInquiryProcessor getEvents,
            IGetQuestionsInquiryProcessor getQuestions)
        {
            _getQueryProcessor = getQueryProcessor;
            _addUserQueryProcessor = addUserQueryProcessor;
            _pagedDataRequestFactory = pagedDataRequestFactory;
            _getGroupsProcessor = getGroupsProcessor;
            _getNotifications = getNotifications;
            _getEvents = getEvents;
            _getQuestions = getQuestions;
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

        [HttpGet]
        public PagedDataInquiryResponse<SchoolUser> GetSchoolUsers()
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var tasks = _getQueryProcessor.GetAllSchoolUsers(request);
            return tasks;
        }

        /// <summary>
        /// Obtiene los grupos asignados al usuario escolar indicado
        /// </summary>
        /// <param name="schoolUserId">El id del usuario escolar</param>
        /// <returns></returns>
        [HttpGet]
        [Route("schoolusers/{schoolUserId:int}/groups")]
        public PagedDataInquiryResponse<Group> GetGroupsForSchoolUser(int schoolUserId)
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
        public PagedDataInquiryResponse<Notification> GetNotificationsForSchoolUser(int schoolUserid)
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
        public PagedDataInquiryResponse<Event> GetEventsForSchoolUser(int schoolUserid)
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var r  =_getEvents.GetEventsForSchoolUser(schoolUserid, request);
            return r;
        }

        /// <summary>
        /// Obtiene una lista de las preguntas creadas por el usuario escolar
        /// </summary>
        /// <param name="schoolUserid">El id del usuario escolar del que se desea conocer sus preguntas</param>
        /// <returns>Una lista con las preguntas creadas por el usuario escolar</returns>
        [HttpGet]
        [Route("schoolusers/{schoolUserId:int}/questions")]
        public PagedDataInquiryResponse<Question> GetQuestionsForSchoolUser(int schoolUserid)
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var r = _getQuestions.GetQuestionsForSchoolUser(schoolUserid, request);
            return r;
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
        public IHttpActionResult AddSchoolUser(NewSchoolUser newUser)
        {
            var user = _addUserQueryProcessor.AddUser(newUser);
            var result = new ModelPostedActionResult<SchoolUser>(Request, user);
            return result;
        }
    }
}
