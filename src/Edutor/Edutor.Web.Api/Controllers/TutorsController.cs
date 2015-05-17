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
        /// <param name="tutorId">El id del tutor a recuperar</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(Tutor))]
        public Tutor GetSchoolUser(int tutorId)
        {
            var s = _getQueryProcessor.GetTutor(tutorId);
            return s;
        }

        /// <summary>
        /// Obtiene todos los estudiantes asignados al tutor asignado
        /// </summary>
        /// <param name="tutorId">El grupo del que se desea conocer los profesores</param>
        /// <returns>Una lista con los profesores asignados a cada grupo</returns>
        [HttpGet]
        [Route("tutors/{tutorId:int}/students")]
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
        [ResponseType(typeof(Tutor))]
        public IHttpActionResult AddTutor(NewTutor newTutor)
        {
            var user = _addUserQueryProcessor.AddUser(newTutor);
            var result = new ModelPostedActionResult<Tutor>(Request, user);
            return result;
        }
    }
}
