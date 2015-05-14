using Edutor.Web.Api.MaintenanceProcessing;
using Edutor.Web.Api.Models.NewModels;
//using Edutor.Web.Api.QueryProcessing;
using System.Net.Http;
using System.Web.Http;

namespace Edutor.Web.Api.Controllers
{
    [Edutor.Web.Common.UnitOfWorkActionFilter]
    public class GroupsController : ApiController
    {

        private readonly IPostGroupMaintenanceProcessor _addUserQueryProcessor;
        private readonly IPostEnrollmentMaintenanceProcessor _postEnrollmentMaintenanceProcessor;
        private readonly IPostTeachingMaintenanceProcessor _postTeachingMaintenanceProcessor;

        public GroupsController(IPostGroupMaintenanceProcessor addUserQueryProcessor,
           IPostEnrollmentMaintenanceProcessor postEnrollmentMaintenanceProcessor,
           IPostTeachingMaintenanceProcessor postTeachingMaintenanceProcessor)
        {
            _addUserQueryProcessor = addUserQueryProcessor;
            _postEnrollmentMaintenanceProcessor = postEnrollmentMaintenanceProcessor;
            _postTeachingMaintenanceProcessor = postTeachingMaintenanceProcessor;
        }



        [HttpPost]
        public IHttpActionResult AddGroup(HttpRequestMessage requestMessage, NewGroup newUser)
        {
            var user = _addUserQueryProcessor.AddGroup(newUser);
            var result = new ModelPostedActionResult<NewGroup>(requestMessage, user);
            return result;
        }

        [HttpGet]
        [Route("students/{studentId:int}/groups")]
        public string GetGroupsFromStudent(int studentId)
        {
            return "xD";
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
