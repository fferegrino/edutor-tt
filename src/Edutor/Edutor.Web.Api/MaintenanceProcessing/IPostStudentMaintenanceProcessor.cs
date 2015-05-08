using Edutor.Common;
using Edutor.Common.TypeMapping;
using Edutor.Data.QueryProcessors;
using Edutor.Web.Api.LinkServices;
using Edutor.Web.Api.Models;
using Edutor.Web.Api.Models.NewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.MaintenanceProcessing
{
    public interface IPostStudentMaintenanceProcessor
    {
        NewStudent AddStudent(NewStudent student);
    }
    public class PostStudentMaintenanceProcessor : IPostStudentMaintenanceProcessor
    {

        private readonly IAutoMapper _autoMapper;
        private readonly IAddStudentQueryProcessor _addUserQueryProcessor;
        private readonly IStudentsLinkService _linkServices;

        public PostStudentMaintenanceProcessor(IAutoMapper autoMapper, IAddStudentQueryProcessor addUserQueryProcessor, IStudentsLinkService linkServices)
        {
            _autoMapper = autoMapper;
            _addUserQueryProcessor = addUserQueryProcessor;
            _linkServices = linkServices;
        }


        public NewStudent AddStudent(NewStudent student)
        {
            var userEntity = _autoMapper.Map<Data.Entities.Student>(student);
            _addUserQueryProcessor.AddStudent(userEntity);
            var returnUser = _autoMapper.Map<NewStudent>(userEntity);

            student.StudentId = userEntity.StudentId;
            //newUser.Type = userEntity.Type;

            // TODO Implement link service here
            _linkServices.AddSelfLink(student);
            _linkServices.AddTutorLink(student);

            return student;
        }
    }
}
