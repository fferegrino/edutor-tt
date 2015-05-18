﻿using Edutor.Data.Entities;
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

        QueryResult<Question> GetQuestionsForStudent(int studentId, PagedDataRequest requestInfo);

        Question GetQuestion(int questionId);

    }
}