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
        private readonly IPagedDataRequestFactory _pagedDataRequestFactory;

        public SchoolUsersController(IPostSchoolUserMaintenanceProcessor addUserQueryProcessor,
            IGetSchoolUsersInquiryProcessor getQueryProcessor, 
            IPagedDataRequestFactory pagedDataRequestFactory,
            IGetGroupsInquiryProcessor getGroupsProcessor)
        {
            _getQueryProcessor = getQueryProcessor;
            _addUserQueryProcessor = addUserQueryProcessor;
            _pagedDataRequestFactory = pagedDataRequestFactory;
            _getGroupsProcessor = getGroupsProcessor;
        }

        [HttpGet]
        public PagedDataInquiryResponse<SchoolUser> GetSchoolUsers()
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var tasks = _getQueryProcessor.GetAllSchoolUsers(request);
            return tasks;
        }


        [HttpGet]
        [Route("schoolusers/{schoolUserId:int}/groups")]
        public PagedDataInquiryResponse<Group> GetGroupsForSchoolUser(int schoolUserId)
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var tasks = _getGroupsProcessor.GetGroupsForSchoolUser(schoolUserId, request);
            return tasks;
        }


        [HttpGet]
        public SchoolUser GetSchoolUser(int id)
        {
            var s = _getQueryProcessor.GetSchoolUser(id);
            return s;
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
