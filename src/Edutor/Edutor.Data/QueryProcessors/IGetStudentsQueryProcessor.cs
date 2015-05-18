﻿using Edutor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.QueryProcessors
{
    public interface IGetStudentsQueryProcessor
    {
        QueryResult<Student> GetStudents(PagedDataRequest requestInfo);

        QueryResult<Student> GetStudentsForGroup(int groupId, PagedDataRequest requestInfo);

        QueryResult<Student> GetStudentsForTutor(int tutorId, PagedDataRequest requestInfo);

        Student GetStudent(int studentId);

        Student GetStudent(string curp);

        Student GetStudentByToken(string token);

        QueryResult<Invitation> GetStudentsForEvent(int eventId, PagedDataRequest request);

        QueryResult<Answer> GetStudentsForQuestion(int eventId, PagedDataRequest requestInfo);

        QueryResult<NotificationDetail> GetStudentsForNotification(int notificationId, PagedDataRequest requestInfo);
    }
}
