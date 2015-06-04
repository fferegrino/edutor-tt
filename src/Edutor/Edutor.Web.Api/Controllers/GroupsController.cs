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
using Edutor.Web.Common.Filters;

namespace Edutor.Web.Api.Controllers
{
    /// <summary>
    /// Los extremos de grupos proveen la capacidad de agregar, modificar y eliminar grupos dentro de Edutor, también permiten vincular alumnos con grupos y grupos con profesores.
    /// Todos los extremos dentro de este conjunto requieren de algún nivel de autorización.
    /// </summary>
    [Edutor.Web.Common.UnitOfWorkActionFilter]
    public class GroupsController : ApiController
    {

        private readonly IPostGroupMaintenanceProcessor _addUserQueryProcessor;
        private readonly IPostEnrollmentMaintenanceProcessor _postEnrollmentMaintenanceProcessor;
        private readonly IPostTeachingMaintenanceProcessor _postTeachingMaintenanceProcessor;
        private readonly IGetSchoolUsersInquiryProcessor _schoolUsersIP;
        private readonly IGetStudentsInquiryProcessor _studentsIP;
        private readonly IGetTutorsInquiryProcessor _getTutors;
        private readonly IPatchGroupMaintenanceProcessor _patchGroups;
        private readonly IDeleteGroupMaintenanceProcessor _deleteGroups;
        private readonly IGetGroupsInquiryProcessor _getGroups;
        private readonly IPagedDataRequestFactory _pagedDataRequestFactory;

        public GroupsController(IPostGroupMaintenanceProcessor addUserQueryProcessor,
           IPostEnrollmentMaintenanceProcessor postEnrollmentMaintenanceProcessor,
           IPostTeachingMaintenanceProcessor postTeachingMaintenanceProcessor,
            IGetSchoolUsersInquiryProcessor schoolUsersIP,
            IGetStudentsInquiryProcessor studentsIP,
            IGetTutorsInquiryProcessor getTutors,
            IPatchGroupMaintenanceProcessor patchGroups,
            IDeleteGroupMaintenanceProcessor deleteGroups,
            IPagedDataRequestFactory pagedDataRequestFactory,
            IGetGroupsInquiryProcessor getGroups)
        {
            _getTutors = getTutors;
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
        /// Regresa una lista paginada de todos los grupos que están registrados en el sistema.
        /// Este extremo solo puede ser accedido por un usuario administrador.
        /// </summary>
        /// <returns>Una lista paginada de todos los grupos que existen en el sistema.</returns>
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
        /// Obtiene el grupo indicado por su identificador único, 
        /// Un usuario administrador podrá acceder a la información de todos los grupos, 
        /// mientras que cualquier otro usuario podrá acceder únicamente a los grupos con los que tiene relación.
        /// </summary>
        /// <param name="groupId">El identificador único del grupo a obtener.</param>
        /// <returns>Devuelve el grupo deseado, en caso de que exista y el usuario tenga permiso para acceder a él.</returns>
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
        /// Obtiene el grupo indicado por su nombre, 
        /// Un usuario administrador podrá acceder a la información de todos los grupos, 
        /// mientras que cualquier otro usuario podrá acceder únicamente a los grupos con los que tiene relación.
        /// </summary>
        /// <param name="groupName">El nombre del grupo a obtener.</param>
        /// <returns>Devuelve el grupo deseado, en caso de que exista y el usuario tenga permiso para acceder a él.</returns>
        [HttpGet]
        [ResponseType(typeof(Group))]
        [Route("groups/name/{groupName:regex(" + Constants.CommonRoutingDefinitions.GroupName + ")}")]
        [Authorize]
        public Group GetGroup(string groupName)
        {
            var tasks = _getGroups.GetGroup(groupName);
            return tasks;

        }


        /// <summary>
        /// Obtiene una lista paginada con los usuarios escolares (profesores) relacionados con el grupo indicado.
        /// Este extremo es accesible únicamente para usuarios administradores.
        /// </summary>
        /// <param name="groupId">El identificador único del grupo del que se desea conocer los profesores.</param>
        /// <returns>Una lista paginada con los usuarios escolares asignados al grupo indicado.</returns>
        [Route("groups/{groupId:int}/schoolusers")]
        [HttpGet]
        [ResponseType(typeof(PagedDataResponse<SchoolUser>))]
        [Authorize(Roles = Constants.RoleNames.Administrator)]
        public PagedDataResponse<SchoolUser> GetSchoolUsersForGroup(int groupId)
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var r = _schoolUsersIP.GetSchoolUsersForGroup(groupId, request);
            return r;
        }

        /// <summary>
        /// Obtiene una lista paginada con los tutores relacionados con el grupo indicado.
        /// Este extremo es accesible únicamente para usuarios escolares.
        /// </summary>
        /// <param name="groupId">El identificador único del grupo del que se desea conocer los tutores.</param>
        /// <returns>Una lista paginada con los tutores asignados al grupo indicado.</returns>
        [Route("groups/{groupId:int}/tutors")]
        [HttpGet]
        [Authorize(Roles = Constants.RoleNames.SchoolUser)]
        public PagedDataResponse<Tutor> GetTutorsForGroup(int groupId)
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var r = _getTutors.GetTutorsForGroup(groupId, request);
            return r;
        }


        /// <summary>
        /// Obtiene una lista paginada con los estudiantes relacionados con el grupo indicado.
        /// Este extremo es accesible únicamente para usuarios escolares,
        /// un usuario administrador podrá consultar información de cualquier grupo, mientras que un profesor únicamente de los grupos a los que pertenence.
        /// </summary>
        /// <param name="groupId">El identificador único del grupo del que se desea conocer los estudiantes.</param>
        /// <returns>Una lista paginada con los estudiantes pertenecientes al grupo indicado.</returns>
        [HttpGet]
        [Route("groups/{groupId:int}/students")]
        [Authorize(Roles = Constants.RoleNames.SchoolUser)]
        public PagedDataResponse<Student> GetStudentsForGroup(int groupId)
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var r = _studentsIP.GetStudentsForGroup(groupId, request);
            return r;
        }


        /// <summary>
        /// Añade un nuevo grupo al sistema Edutor.
        /// Este extremo es accesible únicamente para usuarios administradores.
        /// </summary>
        /// <param name="newGroup">La información del nuevo grupo a registrar.</param>
        /// <returns>El grupo creado en caso de que la operación se haya realizado con éxito.</returns>
        [HttpPost]
        [Route("groups")]
        [ResponseType(typeof(Group))]
        [Authorize(Roles = Constants.RoleNames.Administrator)]
        [ValidationActionFilter]
        public IHttpActionResult AddGroup(NewGroup newGroup)
        {
            var user = _addUserQueryProcessor.AddGroup(newGroup);
            var result = new ModelPostedActionResult<Group>(Request, user);
            return result;
        }

        /// <summary>
        /// Modifica el grupo de acuerdo a lo enviado en el el cuerpo de la petición,
        /// cualquier propiedad faltante o cuyo valor sea nulo no será modificada.
        /// Este extremo es accesible por usuarios administradores unicamente.
        /// </summary>
        /// <param name="group">Los nuevos valores del grupo.</param>
        /// <returns>El grupo modificado en caso de que la operación se haya realizado con éxito.</returns>
        [HttpPatch]
        [Route("groups")]
        [Authorize(Roles = Constants.RoleNames.Administrator)]
        [ResponseType(typeof(Group))]
        [ValidationActionFilter]
        public IHttpActionResult UpdateGroup(ModifiableGroup group)
        {
            var m = _patchGroups.UpdateGroup(group);
            return new ModelUpdatedActionResult<Group>(Request, m);
        }

        /// <summary>
        /// Establece un vínculo entre un grupo y un estudiante.
        /// Este extremo es accesible únicamente por usuarios administradores.
        /// </summary>
        /// <param name="groupId">El identificador único del grupo al que se agregará el estudiante.</param>
        /// <param name="studentId">El identificador único del estudiante que se agregará al grupo.</param>
        /// <returns>Un código de estatus (No Content) si es que la acción se concluyó correctamente.</returns>
        [HttpPut]
        [Route("groups/{groupId:int}/students/{studentId:int}")]
        [Authorize(Roles = Constants.RoleNames.Administrator)]
        public IHttpActionResult AddStudentToGroup(int groupId, int studentId)
        {
            _postEnrollmentMaintenanceProcessor.AddEnrollment(studentId, groupId);
            return new ModelsLinkedActionResult(Request);
        }

        /// <summary>
        /// Establece un vínculo entre un grupo y un profesor.
        /// Este extremo es accesible únicamente por usuarios administradores.
        /// </summary>
        /// <param name="groupId">El identificador único del grupo al que se agregará el usuario escolar.</param>
        /// <param name="schoolUserId">El identificador único del usuario escolar que se agregará al grupo.</param>
        /// <returns>Un código de estatus (No Content) si es que la acción se concluyó correctamente.</returns>
        [HttpPut]
        [Route("groups/{groupId:int}/schoolusers/{schoolUserId:int}")]
        public IHttpActionResult AddTeacherToGroup(int groupId, int schoolUserId)
        {
            _postTeachingMaintenanceProcessor.AddTeaching(schoolUserId, groupId);
            return new ModelsLinkedActionResult(Request);
        }

        /// <summary>
        /// Elimina el grupo especificado del sistema, 
        /// esta acción elimina los vínculos estudiante-grupo y profesor-grupo.
        /// Este extremo es accesible únicamente por usuarios administradores.
        /// </summary>
        /// <param name="groupId">El identificador único del grupo a eliminar.</param>
        /// <returns>Un código de estatus (No Content) si es que la acción se concluyó correctamente.</returns>
        [HttpDelete]
        [Authorize(Roles = Constants.RoleNames.Administrator)]
        [Route("groups/{groupId:int}")]
        public IHttpActionResult DeleteGroup(int groupId)
        {
            _deleteGroups.Delete(groupId);
            return new ModelDeletedActionResult(Request);

        }

        /// <summary>
        /// Elimina el vinculo establecido entre un estudiante y un grupo.
        /// Este extremo es accesible únicamente por usuarios administradores.
        /// </summary>
        /// <param name="groupId">El identificador único del grupo del que se eliminará el estudiante.</param>
        /// <param name="studentId">El identificador único del estudiante que se eliminará del grupo.</param>
        /// <returns>Un código de estatus (No Content) si es que la acción se concluyó correctamente.</returns>
        [HttpDelete]
        [Route("groups/{groupId:int}/students/{studentId:int}")]
        [Authorize(Roles = Constants.RoleNames.Administrator)]
        public IHttpActionResult DeleteStudentFromGroup(int groupId, int studentId)
        {
            _deleteGroups.UnlinkStudent(groupId, studentId);
            return new ModelDeletedActionResult(Request);
        }

        /// <summary>
        /// Elimina el vínculo establecido entre un profesor y un grupo.
        /// Este extremo es accesible únicamente por usuarios administradores.
        /// </summary>
        /// <param name="groupId">El identificador único del grupo del que se eliminará el usuario escolar.</param>
        /// <param name="schoolUserId">El identificador único del usuario escolar que se eliminará del grupo.</param>
        /// <returns>Un código de estatus (No Content) si es que la acción se concluyó correctamente.</returns>
        [HttpDelete]
        [Route("groups/{groupId:int}/schoolusers/{schoolUserId:int}")]
        [Authorize(Roles = Constants.RoleNames.Administrator)]
        public IHttpActionResult DeleteTeacherFromGroup(int groupId, int schoolUserId)
        {
            _deleteGroups.UnlinkSchoolUser(groupId, schoolUserId);
            return new ModelDeletedActionResult(Request);
        }



    }
}
