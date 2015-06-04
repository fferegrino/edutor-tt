using Edutor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.QueryProcessors
{
    public interface IGetUsersQueryProcessor
    {
        QueryResult<User> GetSchoolUsers(PagedDataRequest requestInfo);

        QueryResult<TeacherForStudent> GetTeachersForStudent(int studentId, PagedDataRequest requestInfo);

        QueryResult<User> GetTutors(PagedDataRequest requestInfo);

        QueryResult<TutorForTeacher> GetTutorsForGroup(string groupName, PagedDataRequest requestInfo);

        QueryResult<TutorForTeacher> GetTutorsForGroup(int groupId, PagedDataRequest requestInfo);

        QueryResult<TutorForTeacher> GetTutorsForTeacher(int teacherId, PagedDataRequest requestInfo);
        

        User GetSchoolUser(int userId);

        User GetTutor(int userId);

        User GetSchoolUser(string curp);

        User GetTutor(string curp);

        QueryResult<User> GetSchoolUsersForGroup(int groupId, PagedDataRequest requestInfo);
    }
}
