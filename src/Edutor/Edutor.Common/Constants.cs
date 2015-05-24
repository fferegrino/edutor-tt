using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Common
{
    public static class Constants
    {
        public static class MediaTypeNames
        {
            public const string ApplicationXml = "application/xml";
            public const string TextXml = "text/xml";
            public const string ApplicationJson = "application/json";
            public const string TextJson = "text/json";
        }


        public static class Paging
        {
            public const int MinPageSize = 1;
            public const int MinPageNumber = 1;
            public const int DefaultPageNumber = 1;
            public const string PagedQueryStringFormat = "pageNumber={0}&pageSize={1}";
        }


        public static class CommonParameterNames
        {
            public const string PageNumber = "pageNumber";
            public const string PageSize = "pageSize";
        }

        public static class CommonLinkRelValues
        {
            public const string Self = "self";
            public const string All = "all";
            public const string CurrentPage = "currentPage";
            public const string PreviousPage = "previousPage";
            public const string NextPage = "nextPage";

            public const string StudentsRel = "students";
            public const string StudentRel = "student";
            public const string TeachersRel = "teacher";
            public const string TutorRel = "tutor";
            public const string SchoolUsersRel = "schoolusers";
            public const string SchoolUserRel = "schooluser";
            public const string QuestionsRel = "questions";
            public const string NotificationsRel = "notifications";
            public const string EventsRel = "events";
            public const string ConversationsRel = "conversations";
            public const string ConversationRel = "conversation";
            public const string MessagesRel = "messages";
            public const string AttendeesRel = "attendees";
            public const string NotificationDetailsRel = "details";
            public const string GroupsRel = "groups";
            public const string AnswersRel = "answers";
            public const string AnswerRel = "answer";
            public const string RsvpRel = "rsvp";
            public const string SeenRel = "seen";
        }

        public static class CommonRoutingDefinitions
        {
            public const string ApiSegmentName = "";
            public const string CurpRegex = "^[A-Za-z]{4}[A-Za-z0-9]+$";
            public const string Token = "^[A-Za-z][A-Za-z0-9]{9}$";

        }

        public static class SchemeTypes
        {
            public const string Basic = "basic";
        }

        public static class RoleNames
        {
            public const string Teacher = "Teacher";
            public const string Administrator = "Administrator";
            public const string Tutor = "Tutor";
            public const string All = Teacher + "," + Administrator + "," + Tutor;
            public const string TeacherAndTutor = Teacher + "," + Tutor;
            public const string SchoolUser = Teacher + "," + Administrator;
        }
        public static class CustomClaimTypes
        {
            public const string StudentId = "StudentId";
            public const string SchoolUserId = "SchoolUserId";
            public const string TutorId = "TutorId";
            public const string UserId = "UserId";
        }
    }
}
