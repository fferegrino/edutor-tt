using Edutor.Common.TypeMapping;
using Edutor.Data.QueryProcessors;
using Edutor.Web.Api.Models.NewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.MaintenanceProcessing
{
    public interface IPostTeachingMaintenanceProcessor
    {
        void AddTeaching(int schoolUserId, int groupId);
    }

    public class PostTeachingMaintenanceProcessor : IPostTeachingMaintenanceProcessor
    {
        

        private readonly IAutoMapper _autoMapper;
        private readonly IAddTeachingQueryProcessor _addTeachingQueryProcessor;

        public PostTeachingMaintenanceProcessor(IAutoMapper autoMapper, IAddTeachingQueryProcessor addTeachingQueryProcessor)
        {
            _autoMapper = autoMapper;
            _addTeachingQueryProcessor = addTeachingQueryProcessor;
        }

        public void AddTeaching(int schoolUserId, int groupId)
        {
            var enrollment = _autoMapper.Map<Data.Entities.Teaching>(new NewTeaching { SchoolUserId = schoolUserId, GroupId = groupId });
            _addTeachingQueryProcessor.AddEnrollment(enrollment);
            
        }
    }
}
