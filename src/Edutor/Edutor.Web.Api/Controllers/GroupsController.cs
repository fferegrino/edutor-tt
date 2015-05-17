using Edutor.Web.Api.InquiryProcessing;
using Edutor.Web.Api.MaintenanceProcessing;
using Edutor.Web.Api.Models;
using Edutor.Web.Api.Models.NewModels;
using Edutor.Web.Api.Models.ReturnTypes;
//using Edutor.Web.Api.QueryProcessing;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Edutor.Web.Api.Controllers
{
    [Edutor.Web.Common.UnitOfWorkActionFilter]
    public class GroupsController : ApiController
    {

        private readonly IPostGroupMaintenanceProcessor _addUserQueryProcessor;
        private readonly IPostEnrollmentMaintenanceProcessor _postEnrollmentMaintenanceProcessor;
        private readonly IPostTeachingMaintenanceProcessor _postTeachingMaintenanceProcessor;
        private readonly IGetSchoolUsersInquiryProcessor _schoolUsersIP;
        private readonly IGetStudentsInquiryProcessor _studentsIP;
        private readonly IGetGroupsInquiryProcessor _getGroups;
        private readonly IPagedDataRequestFactory _pagedDataRequestFactory;

        public GroupsController(IPostGroupMaintenanceProcessor addUserQueryProcessor,
           IPostEnrollmentMaintenanceProcessor postEnrollmentMaintenanceProcessor,
           IPostTeachingMaintenanceProcessor postTeachingMaintenanceProcessor,
            IGetSchoolUsersInquiryProcessor schoolUsersIP,
            IGetStudentsInquiryProcessor studentsIP,
            IPagedDataRequestFactory pagedDataRequestFactory,
            IGetGroupsInquiryProcessor getGroups)
        {
            _addUserQueryProcessor = addUserQueryProcessor;
            _postEnrollmentMaintenanceProcessor = postEnrollmentMaintenanceProcessor;
            _postTeachingMaintenanceProcessor = postTeachingMaintenanceProcessor;
            _schoolUsersIP = schoolUsersIP;
            _pagedDataRequestFactory = pagedDataRequestFactory;
            _studentsIP = studentsIP;
            _getGroups = getGroups;
        }



        [HttpPost]
        public IHttpActionResult AddGroup(HttpRequestMessage requestMessage, NewGroup group)
        {
            var user = _addUserQueryProcessor.AddGroup(group);
            var result = new ModelPostedActionResult<Group>(requestMessage, user);
            return result;
        }

        /// <summary>
        /// Obtiene los profesores del grupo indicado
        /// </summary>
        /// <param name="groupId">El grupo del que se desea conocer los profesores</param>
        /// <returns>Una lista con los profesores asignados a cada grupo</returns>
        [HttpGet]
        [Route("groups/{groupId:int}/schoolusers")]
        public PagedDataInquiryResponse<SchoolUser> GetSchoolUsersForGroup(int groupId)
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var r = _schoolUsersIP.GetSchoolUsersForGroup(groupId, request);
            return r;
        }

        /// <summary>
        /// Obtiene los estudiantes del grupo indicado
        /// </summary>
        /// <param name="groupId">El grupo del que se desea conocer los estudiantes</param>
        /// <returns>Una lista con los estudiantes asignados a cada grupo</returns>
        [HttpGet]
        [Route("groups/{groupId:int}/students")]
        public PagedDataInquiryResponse<Student> GetStudentsForGroup(int groupId)
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var r = _studentsIP.GetStudentsForGroup(groupId, request);
            return r;
        }


        [HttpGet]
        [ResponseType(typeof(Group))]
        [Route("groups/{groupId:int}")]
        public Group GetGroup(int groupId)
        {
            var tasks = _getGroups.GetGroup(groupId);
            return tasks;

        }

        [HttpGet]
        public PagedDataInquiryResponse<Group> GetGroups()
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var tasks = _getGroups.GetAllGroups(request);
            return tasks;
        }



        /// <summary>
        /// Add the student to a group
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("groups/{groupId:int}/students/{studentId:int}")]
        public string AddStudentToGroup(int groupId, int studentId)
        {
            _postEnrollmentMaintenanceProcessor.AddEnrollment(studentId, groupId);
            return "Group " + studentId;
        }

        [HttpPost]
        [Route("groups/{groupId:int}/schoolusers/{schoolUserId:int}")]
        public string AddTeacherToGroup(int groupId, int schoolUserId)
        {
            _postTeachingMaintenanceProcessor.AddTeaching(schoolUserId, groupId);
            return "Group " + schoolUserId;
        }
    }
}
