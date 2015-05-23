using Edutor.Common.TypeMapping;
using Edutor.Data.QueryProcessors;
using Ent = Edutor.Data.Entities;
using Edutor.Web.Api.LinkServices;
using Edutor.Web.Api.Models.ModModels;
using Edutor.Web.Api.Models.ReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.MaintenanceProcessing
{
    public interface IPatchStudentMaintenanceProcessor
    {
        Student UpdateStudent(ModifiableStudent schoolUser);
    }


    public class PatchStudentMaintenanceProcessor : IPatchStudentMaintenanceProcessor
    {

        private readonly IAutoMapper _autoMapper;
        private readonly IUpdateStudentsQueryProcessor _addUserQueryProcessor;
        private readonly IGetStudentsQueryProcessor _getStudents;
        private readonly IStudentsLinkService _linkServices;

        public PatchStudentMaintenanceProcessor(IAutoMapper autoMapper,
                    IUpdateStudentsQueryProcessor addUserQueryProcessor,
            IGetStudentsQueryProcessor getStudents,
                    IStudentsLinkService linkServices)
        {
            _autoMapper = autoMapper;
            _addUserQueryProcessor = addUserQueryProcessor;
            _linkServices = linkServices;
            _getStudents = getStudents;
        }

        public Student UpdateStudent(ModifiableStudent schoolUser)
        {
            var a = _autoMapper.Map<Ent.Student>(schoolUser);
            var b = _getStudents.GetStudent(schoolUser.StudentId);

            #region Modify
            b.Address = a.Address ?? b.Address;
            b.Name = a.Name ?? b.Name;
            b.Phone = a.Phone ?? b.Phone;
            b.TutorRelationship = a.TutorRelationship ?? b.TutorRelationship;
            #endregion

            _addUserQueryProcessor.Update(b);
            var ret = _autoMapper.Map<Student>(b);
            _linkServices.AddAllLinks(ret);
            return ret;
        }
    }
}
