using Edutor.Common;
using Edutor.Web.Api.InquiryProcessing;
using Edutor.Web.Api.MaintenanceProcessing;
using Edutor.Web.Api.Models;
using Edutor.Web.Api.Models.NewModels;
using Edutor.Web.Api.Models.ReturnTypes;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Edutor.Web.Api.Controllers
{
    [Edutor.Web.Common.UnitOfWorkActionFilter]
    public class TutorsController : ApiController
    {
        private readonly IPostTutorMaintenanceProcessor _addUserQueryProcessor;
        private readonly IGetTutorsInquiryProcessor _getQueryProcessor;
        private readonly IGetStudentsInquiryProcessor _getStudentsQueryProcessor;
        private readonly IPagedDataRequestFactory _pagedDataRequestFactory;

        public TutorsController(IPostTutorMaintenanceProcessor addUserQueryProcessor,
            IGetTutorsInquiryProcessor getQueryProcessor,
            IGetStudentsInquiryProcessor getStudentsQueryProcessor,
            IPagedDataRequestFactory pagedDataRequestFactory)
        {
            _addUserQueryProcessor = addUserQueryProcessor;
            _getQueryProcessor = getQueryProcessor;
            _getStudentsQueryProcessor = getStudentsQueryProcessor;
            _pagedDataRequestFactory = pagedDataRequestFactory;
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
            var s = _getQueryProcessor.GetTutor(tutorId);
            return s;
        }

        /// <summary>
        /// Obtiene el tutor indicado
        /// </summary>
        /// <param name="curp">La Clave Única de Registro de Población del tutor</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(Tutor))]
        [Route("tutors/{curp:regex(" + Constants.CommonRoutingDefinitions.CurpRegex +")}")]
        public Tutor GetTutor(string curp)
        {
            var s = _getQueryProcessor.GetTutor(curp);
            return s;
        }

        /// <summary>
        /// Obtiene todos los tutores registrados en el sistema
        /// </summary>
        /// <returns>Una respuesta paginada de todos los tutores en el sistema</returns>
        [HttpGet]
        [ResponseType(typeof(PagedDataInquiryResponse<Tutor>))]
        [Route("tutors")]
        public PagedDataInquiryResponse<Tutor> GetTutors()
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var s = _getQueryProcessor.GetAllTutors(request);
            return s;
        }

        /// <summary>
        /// Obtiene todos los estudiantes asignados al tutor asignado
        /// </summary>
        /// <param name="tutorId">El grupo del que se desea conocer los profesores</param>
        /// <returns>Una lista con los profesores asignados a cada grupo</returns>
        [HttpGet]
        [Route("tutors/{tutorId:int}/students")]
        [ResponseType(typeof(PagedDataInquiryResponse<Tutor>))]
        public PagedDataInquiryResponse<Student> GetStudentsForTutor(int tutorId)
        {
            var request = _pagedDataRequestFactory.Create(Request.RequestUri);
            var r = _getStudentsQueryProcessor.GetStudentsForTutor(tutorId, request);
            return r;
        }


        /// <summary>
        /// Agrega un nuevo tutor al sistema
        /// </summary>
        /// <param name="newTutor">El nuevo tutor a ingresar</param>
        /// <returns></returns>
        [HttpPost]
        [Route("tutors")]
        [ResponseType(typeof(Tutor))]
        public IHttpActionResult AddTutor(NewTutor newTutor)
        {
            var user = _addUserQueryProcessor.AddUser(newTutor);
            var result = new ModelPostedActionResult<Tutor>(Request, user);
            return result;
        }
    }
}
