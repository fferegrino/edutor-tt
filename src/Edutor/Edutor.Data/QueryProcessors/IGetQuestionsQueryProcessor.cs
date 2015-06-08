using Edutor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.QueryProcessors
{
    public interface IGetQuestionsQueryProcessor
    {
        QueryResult<Question> GetQuestionsForSchoolUser(int schoolUser, PagedDataRequest requestInfo);

        QueryResult<Answer> GetQuestionsForStudent(int studentId, PagedDataRequest requestInfo);

        QueryResult<Question> GetQuestionsForSchoolUser(int schoolUser, int groupId, PagedDataRequest requestInfo);

        Question GetQuestion(int questionId);

    }
}
