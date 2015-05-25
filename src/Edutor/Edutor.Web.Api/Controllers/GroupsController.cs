using Edutor.Web.Api.InquiryProcessing;
using Edutor.Web.Api.MaintenanceProcessing;
using Edutor.Web.Api.Models;
using Edutor.Web.Api.Models.NewModels;
using Edutor.Web.Api.Models.ModModels;
using Edutor.Web.Api.Models.ReturnTypes;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Edutor.Common;

namespace Edutor.Web.Api.Controllers
{
    /// <summary>
    /// Conjunto de extremos REST que permiten operar con los servicios de creación y manipulación de grupos que ofrece la plataforma
    /// </summary>
    [Edutor.Web.Common.UnitOfWorkActionFilter]
    public class GroupsController : ApiController
    {

        private readonly IPostGroupMaintenanceProcessor _addUserQueryProcessor;
        private readonly IPostEnrollmentMaintenanceProcessor _postEnrollmentMaintenanceProcessor;
        private readonly IPostTeachingMaintenanceProcessor _postTeachingMaintenanceProcessor;
        private readonly IGetSchoolUsersInquiryProcessor _schoolUsersIP;
        private readonly IGetStudentsInquiryProcessor _studentsIP;
        private readonly IPatchGroupMaintenanceProcessor _patchGroups;
        private readonly IDeleteGroupMaintenanceProcessor _deleteGroups;
        private readonly IGetGroupsInquiryProcessor _getGroups;
        private readonly IPagedDataRequestFactory _pagedDataRequestFactory;

        public GroupsController(IPostGroupMaintenanceProcessor addUserQueryProcessor,
           IPostEnrollmentMaintenanceProcessor postEnrollmentMaintenanceProcessor,
           IPostTeachingMaintenanceProcessor postTeachingMaintenanceProcessor,
            IGetSchoolUsersInquiryProcessor schoolUsersIP,
            IGetStudentsInquiryProcessor studentsIP,
            IPatchGroupMaintenanceProcessor patchGroups,
            IDeleteGroupMaintenanceProcessor deleteGroups,
            IPagedDataRequestFactory pagedDataRequestFactory,
            IGetGroupsInquiryProcessor getGroups)
        {
            _patchGroups = patchGroups;
            _addUserQueryProcessor = addUserQueryProcessor;
            _postEnrollmentMaintenanceProcessor = postEnrollmentMaintenanceProcessor;
            _postTeachingMaintenanceProcessor = postTeachingMaintenanceProcessor;
            _schoolUsersIP = schoolUsersIP;
            _pagedDataRequestFactory = pagedDataRequestFactory;
            _studentsIP = studentsIP;
            _getGroups = getGroups;
            _deleteGroups = deleteGroups;
        }


        /// <summary>
        /// Regresa una lista paginada de todos los grupos que existen en el sistema
        /// </summary>
        /// <returns>Una lista paginada de todos los grupos que existen en el sistema</returns>
        [HttpGet]
        [Route("groups")]
        [Authorize(Roles = Constants.RoleNames.Administrator)]
        public PagedDataResponse<Group> GetGroups()
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var tasks = _getGroups.GetAllGroups(request);
            return tasks;
        }

        /// <summary>
        /// Regresa el grupo con el identificador enviado en la URL
        /// </summary>
        /// <param name="groupId">El identificador único del grupo a obtener</param>
        /// <returns>Regresa el grupo deseado o un código de error 404 en caso de que no exista</returns>
        [HttpGet]
        [ResponseType(typeof(Group))]
        [Route("groups/{groupId:int}")]
        [Authorize]
        public Group GetGroup(int groupId)
        {
            var tasks = _getGroups.GetGroup(groupId);
            return tasks;

        }


        /// <summary>
        /// Regresa una lista paginada con los profesores asignados al grupo especificado
        /// </summary>
        /// <param name="groupId">El identificador único del grupo del que se desea conocer los profesores</param>
        /// <returns>Una lista paginada con los profesores asignados al grupo especificado</returns>
        [Route("groups/{groupId:int}/schoolusers")]
        [HttpGet]
        [ResponseType(typeof(PagedDataResponse<SchoolUser>))]
        public PagedDataResponse<SchoolUser> GetSchoolUsersForGroup(int groupId)
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var r = _schoolUsersIP.GetSchoolUsersForGroup(groupId, request);
            return r;
        }

        /// <summary>
        /// Regresa una lista paginada con los estudiantes pertenecientes al grupo especificado
        /// </summary>
        /// <param name="groupId">El identificador único del grupo del que se desea conocer los estudiantes</param>
        /// <returns>Una lista paginada con los estudiantes pertenecientes al grupo especificado</returns>
        [HttpGet]
        [Route("groups/{groupId:int}/students")]
        public PagedDataResponse<Student> GetStudentsForGroup(int groupId)
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var r = _studentsIP.GetStudentsForGroup(groupId, request);
            return r;
        }


        /// <summary>
        /// Da de alta un nuevo grupo en el sistema
        /// </summary>
        /// <param name="newGroup">El nuevo grupo a ingresar</param>
        /// <returns>Mensaje de confirmación de que el grupo fue dado de alta correctamente</returns>
        [HttpPost]
        [Route("groups")]
        [ResponseType(typeof(Group))]
        public IHttpActionResult AddGroup(NewGroup newGroup)
        {
            var user = _addUserQueryProcessor.AddGroup(newGroup);
            var result = new ModelPostedActionResult<Group>(Request, user);
            return result;
        }

        /// <summary>
        /// Modifica el grupo de acuerdo a lo enviado en el el cuerpo de la petición.
        /// <remarks>Cualquier propiedad faltante o cuyo valor sea nulo no será modificada</remarks>
        /// </summary>
        /// <param name="group">Los nuevos valores a asignar</param>
        /// <returns></returns>
        [HttpPatch]
        [Route("groups")]
        [Authorize(Roles = Constants.RoleNames.All)]
        [ResponseType(typeof(Group))]
        public IHttpActionResult UpdateGroup(ModifiableGroup group)
        {
            var m = _patchGroups.UpdateGroup(group);
            return new ModelUpdatedActionResult<Group>(Request, m);
        }

        /// <summary>
        /// Establece un vínculo entre un grupo y un estudiante especificados a través de la URL
        /// </summary>
        /// <param name="groupId">El identificador único del grupo al que se agregará el estudiante</param>
        /// <param name="studentId">El identificador único del estudiante que se agregará al grupo</param>
        /// <returns></returns>
        [HttpPut]
        [Route("groups/{groupId:int}/students/{studentId:int}")]
        public IHttpActionResult AddStudentToGroup(int groupId, int studentId)
        {
            _postEnrollmentMaintenanceProcessor.AddEnrollment(studentId, groupId);
            return new ModelsLinkedActionResult(Request);
        }

        /// <summary>
        /// Establece un vínculo entre un grupo y el profesor especificados a través de la URL
        /// </summary>
        /// <param name="groupId">El identificador único del grupo al que se agregará el usuario escolar</param>
        /// <param name="schoolUserId">El identificador único del usuario escolar que se agregará al grupo</param>
        /// <returns></returns>
        [HttpPut]
        [Route("groups/{groupId:int}/schoolusers/{schoolUserId:int}")]
        public IHttpActionResult AddTeacherToGroup(int groupId, int schoolUserId)
        {
            _postTeachingMaintenanceProcessor.AddTeaching(schoolUserId, groupId);
            return new ModelsLinkedActionResult(Request);
        }

        /// <summary>
        /// Elimina el grupo especificado del sistema.
        /// </summary>
        /// <param name="groupId">El identificador único del grupo a eliminar</param>
        /// <returns>Un código de estatus</returns>
        [HttpDelete]
        [Route("groups/{groupId:int}")]
        public IHttpActionResult DeleteGroup(int groupId)
        {
            _deleteGroups.Delete(groupId);
            return new ModelDeletedActionResult(Request);

        }

        /// <summary>
        /// Elimina el vinculo establecido entre un estudiante y un grupo
        /// </summary>
        /// <param name="groupId">El identificador único del grupo del que se eliminará el estudiante</param>
        /// <param name="studentId">El identificador único del estudiante que se eliminará del grupo</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("groups/{groupId:int}/students/{studentId:int}")]
        public IHttpActionResult DeleteStudentFromGroup(int groupId, int studentId)
        {
            _deleteGroups.UnlinkStudent(groupId, studentId);
            return new ModelDeletedActionResult(Request);
        }

        /// <summary>
        /// Elimina el vínculo establecido entre un profesor y un grupo
        /// </summary>
        /// <param name="groupId">El identificador único del grupo del que se eliminará el usuario escolar</param>
        /// <param name="schoolUserId">El identificador único del usuario escolar que se eliminará del grupo</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("groups/{groupId:int}/schoolusers/{schoolUserId:int}")]
        public IHttpActionResult DeleteTeacherFromGroup(int groupId, int schoolUserId)
        {
            _deleteGroups.UnlinkSchoolUser(groupId, schoolUserId);
            return new ModelDeletedActionResult(Request);
        }



    }
}
