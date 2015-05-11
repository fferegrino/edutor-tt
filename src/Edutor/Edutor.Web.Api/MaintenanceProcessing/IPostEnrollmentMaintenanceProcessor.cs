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
    public interface IPostEnrollmentMaintenanceProcessor
    {
        void AddEnrollment(int studentId, int groupId);
    }

    public class PostEnrollmentMaintenanceProcessor : IPostEnrollmentMaintenanceProcessor
    {

        private readonly IAutoMapper _autoMapper;

        private readonly IAddEnrollmentQueryProcessor _addUserQueryProcessor;

        public PostEnrollmentMaintenanceProcessor(IAutoMapper autoMapper, IAddEnrollmentQueryProcessor addUserQueryProcessor)
        {
            _autoMapper = autoMapper;
            _addUserQueryProcessor = addUserQueryProcessor;
            //_linkServices = linkServices;
        }

        public void AddEnrollment(int studentId, int groupId)
        {
            var enrollment = _autoMapper.Map<Data.Entities.Enrollment>(new NewEnrollment { StudentId = studentId, GroupId = groupId });
            _addUserQueryProcessor.AddEnrollment(enrollment);
        }


        //public NewSchoolUser AddUser(NewSchoolUser newUser)
        //{
        //    var userEntity = _autoMapper.Map<Data.Entities.User>(newUser);
        //    _addUserQueryProcessor.AddUser(userEntity);

        //    newUser.UserId = userEntity.UserId;
        //    newUser.Type = userEntity.Type;

        //    // TODO Implement link service here
        //    _linkServices.AddSelfLink(newUser);

        //    return newUser;
        //}
    }
}
