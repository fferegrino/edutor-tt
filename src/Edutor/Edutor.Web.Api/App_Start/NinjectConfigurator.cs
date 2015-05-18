using Edutor.Common;
using Edutor.Common.Logging;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using log4net.Config;
using NHibernate;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Web.Common;
using Mapping = Edutor.Data.SqlServer.Mapping;
using NHibernate.Context;
using Edutor.Web.Common;
using Edutor.Web.Common.Security;
using Edutor.Common.Security;
using QueryProcessors = Edutor.Data.QueryProcessors;
using SqlProcessors = Edutor.Data.SqlServer.QueryProcessors;
using TM = Edutor.Common.TypeMapping;
using AMC = Edutor.Web.Api.AutoMappingConfigurator;
using AMP = Edutor.Web.Api.MaintenanceProcessing;
using Security = Edutor.Web.Api.Securitiy;
//using AQP = Edutor.Web.Api.QueryProcessing;
using LS = Edutor.Web.Api.LinkServices;
using Edutor.Web.Api.InquiryProcessing;

namespace Edutor.Web.Api
{
    public class NinjectConfigurator
    {
        public void Configure(IKernel container)
        {
            AddBindings(container);
        }

        private void AddBindings(IKernel container)
        {
            ConfigureLog4Net(container);
            ConfigureUserSession(container);
            ConfigureNHibernate(container);
            ConfigureQueryProcessors(container);
            ConfigureAutoMapper(container);
            ConfigureLinkServices(container);
            container.Bind<IDateTime>().To<DateTimeAdapter>().InSingletonScope();
            container.Bind<IPagedDataRequestFactory>().To<PagedDataRequestFactory>().InSingletonScope();
            container.Bind<Securitiy.IBasicSecurityService>().To<Securitiy.BasicSecurityService>().InRequestScope();
        }

        private void ConfigureLinkServices(IKernel container)
        {
            container.Bind<LS.ICommonLinkService>().To<LS.CommonLinkService>();
            container.Bind<LS.ISchoolUsersLinkService>().To<LS.SchoolUsersLinkService>();
            container.Bind<LS.ITutorsLinkService>().To<LS.TutorsLinkService>();
            container.Bind<LS.IStudentsLinkService>().To<LS.StudentsLinkService>();
            container.Bind<LS.IGroupsLinkService>().To<LS.GroupsLinkService>();
            container.Bind<LS.IEventsLinkService>().To<LS.EventsLinkService>();
            container.Bind<LS.IQuestionsLinkService>().To<LS.QuestionsLinkService>();
            container.Bind<LS.INotificationsLinkService>().To<LS.NotificationsLinkService>();

        }

        private void ConfigureAutoMapper(IKernel container)
        {
            container.Bind<TM.IAutoMapper>().To<TM.AutoMapperAdapter>().InSingletonScope();

            container.Bind<TM.IAutoMapperTypeConfigurator>()
                .To<AMC.NewSchoolUserToUserEntityAutoMapperTypeConfigurator>().InSingletonScope();
            container.Bind<TM.IAutoMapperTypeConfigurator>()
                .To<AMC.NewStudentToStudentEntityAutoMapperTypeConfigurator>().InSingletonScope();
            container.Bind<TM.IAutoMapperTypeConfigurator>()
                .To<AMC.NewTutorToUserEntityAutoMapperTypeConfigurator>().InSingletonScope();
            container.Bind<TM.IAutoMapperTypeConfigurator>()
                .To<AMC.NewGroupToGroupEntityAutoMapperTypeConfigurator>().InSingletonScope();
            container.Bind<TM.IAutoMapperTypeConfigurator>()
                .To<AMC.NewEnrollmentToEnrollmentEntityAutoMapperTypeConfigurator>().InSingletonScope();
            container.Bind<TM.IAutoMapperTypeConfigurator>()
                .To<AMC.NewTeachingToTeachingEntityAutoMapperTypeConfigurator>().InSingletonScope();
            container.Bind<TM.IAutoMapperTypeConfigurator>()
                .To<AMC.NewEventToEventEntityAutoMapperTypeConfigurator>().InSingletonScope();
            container.Bind<TM.IAutoMapperTypeConfigurator>()
                .To<AMC.NewQuestionToQuestionEntityAutoMapperTypeConfigurator>().InSingletonScope();
            container.Bind<TM.IAutoMapperTypeConfigurator>()
                .To<AMC.NewNotificationToNotificationEntityAutoMapperTypeConfigurator>().InSingletonScope();

        }

        private void ConfigureQueryProcessors(IKernel container)
        {
            #region Post binding

            container.Bind<QueryProcessors.IAddUserQueryProcessor>().To<SqlProcessors.AddUserQueryProcessor>().InRequestScope();
            container.Bind<QueryProcessors.IAddStudentQueryProcessor>().To<SqlProcessors.AddStudentQueryProcessor>().InRequestScope();
            container.Bind<QueryProcessors.IAddGroupQueryProcessor>().To<SqlProcessors.AddGroupQueryProcessor>().InRequestScope();
            container.Bind<QueryProcessors.IAddEnrollmentQueryProcessor>().To<SqlProcessors.AddEnrollmentQueryProcessor>().InRequestScope();
            container.Bind<QueryProcessors.IAddTeachingQueryProcessor>().To<SqlProcessors.AddTeachingQueryProcessor>().InRequestScope();
            container.Bind<QueryProcessors.IAddEventQueryProcessor>().To<SqlProcessors.AddEventQueryProcessor>().InRequestScope();
            container.Bind<QueryProcessors.IAddInvitationQueryProcessor>().To<SqlProcessors.AddInvitationQueryProcessor>().InRequestScope();
            container.Bind<QueryProcessors.IAddQuestionQueryProcessor>().To<SqlProcessors.AddQuestionQueryProcessor>().InRequestScope();
            container.Bind<QueryProcessors.IAddPossibleAnswerQueryProcessor>().To<SqlProcessors.AddPossibleAnswerQueryProcessor>().InRequestScope();
            container.Bind<QueryProcessors.IAddAnswerQueryProcessor>().To<SqlProcessors.AddAnswerQueryProcessor>().InRequestScope();
            container.Bind<QueryProcessors.IAddNotificationQueryProcessor>().To<SqlProcessors.AddNotificationQueryProcessor>().InRequestScope();
            container.Bind<QueryProcessors.IAddNotificationDetailQueryProcessor>().To<SqlProcessors.AddNotificationDetailQueryProcessor>().InRequestScope();

            container.Bind<AMP.IPostSchoolUserMaintenanceProcessor>().To<AMP.PostSchoolUserMaintenanceProcessor>().InRequestScope();
            container.Bind<AMP.IPostStudentMaintenanceProcessor>().To<AMP.PostStudentMaintenanceProcessor>().InRequestScope();
            container.Bind<AMP.IPostTutorMaintenanceProcessor>().To<AMP.PostTutorMaintenanceProcessor>().InRequestScope();
            container.Bind<AMP.IPostGroupMaintenanceProcessor>().To<AMP.PostGroupMaintenanceProcessor>().InRequestScope();
            container.Bind<AMP.IPostEnrollmentMaintenanceProcessor>().To<AMP.PostEnrollmentMaintenanceProcessor>().InRequestScope();
            container.Bind<AMP.IPostTeachingMaintenanceProcessor>().To<AMP.PostTeachingMaintenanceProcessor>().InRequestScope();
            container.Bind<AMP.IPostEventMaintenanceProcessor>().To<AMP.PostEventMaintenanceProcessor>().InRequestScope();
            container.Bind<AMP.IPostQuestionMaintenanceProcessor>().To<AMP.PostQuestionMaintenanceProcessor>().InRequestScope();
            container.Bind<AMP.IPostNotificationMaintenanceProcessor>().To<AMP.PostNotificationMaintenanceProcessor>().InRequestScope();

            #endregion

            #region Get binding

            container.Bind<QueryProcessors.IGetUsersQueryProcessor>().To<SqlProcessors.GetUsersQueryProcessor>().InRequestScope();
            container.Bind<InquiryProcessing.IGetSchoolUsersInquiryProcessor>().To<InquiryProcessing.GetSchoolUsersInquiryProcessor>().InRequestScope();
            container.Bind<InquiryProcessing.IGetTutorsInquiryProcessor>().To<InquiryProcessing.GetTutorsInquiryProcessor>().InRequestScope();

            container.Bind<QueryProcessors.IGetStudentsQueryProcessor>().To<SqlProcessors.GetStudentsQueryProcessor>().InRequestScope();
            container.Bind<InquiryProcessing.IGetStudentsInquiryProcessor>().To<InquiryProcessing.GetStudentsInquiryProcessor>().InRequestScope();

            container.Bind<QueryProcessors.IGetGroupsQueryProcessor>().To<SqlProcessors.GetGroupsQueryProcessor>().InRequestScope();
            container.Bind<InquiryProcessing.IGetGroupsInquiryProcessor>().To<InquiryProcessing.GetGroupsInquiryProcessor>().InRequestScope();

            container.Bind<QueryProcessors.IGetNotificationsQueryProcessor>().To<SqlProcessors.GetNotificationsQueryProcessor>().InRequestScope();
            container.Bind<InquiryProcessing.IGetNotificationsInquiryProcessor>().To<InquiryProcessing.GetNotificationsInquiryProcessor>().InRequestScope();

            container.Bind<QueryProcessors.IGetEventsQueryProcessor>().To<SqlProcessors.GetEventsQueryProcessor>().InRequestScope();
            container.Bind<InquiryProcessing.IGetEventsInquiryProcessor>().To<InquiryProcessing.GetEventsInquiryProcessor>().InRequestScope();

            container.Bind<QueryProcessors.IGetQuestionsQueryProcessor>().To<SqlProcessors.GetQuestionsQueryProcessor>().InRequestScope();
            container.Bind<InquiryProcessing.IGetQuestionsInquiryProcessor>().To<InquiryProcessing.GetQuestionsInquiryProcessor>().InRequestScope();
            #endregion
        }

        private void ConfigureLog4Net(IKernel container)
        {
            XmlConfigurator.Configure();
            var logManager = new LogManagerAdapter();
            container.Bind<ILogManager>().ToConstant(logManager);
        }

        private void ConfigureNHibernate(IKernel container)
        {
#if DEBUG
            var sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey("edutorDbTest")))
                .CurrentSessionContext("web")
#else
            var sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey("edutorDb")))
                .CurrentSessionContext("web")
#endif
                // TODO: add new mappings
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Mapping.UserMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Mapping.StudentMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Mapping.GroupMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Mapping.TeachingMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Mapping.EnrollmentMap>())

                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Mapping.EventMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Mapping.InvitationMap>())

                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Mapping.QuestionMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Mapping.PossibleAnswerMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Mapping.AnswerMap>())


                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Mapping.NotificationMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Mapping.NotificationDetailMap>())

                .BuildSessionFactory();
            container.Bind<ISessionFactory>().ToConstant(sessionFactory);
            container.Bind<ISession>().ToMethod(CreateSession).InRequestScope();

            // Resolve IActionTransactionHelper at runtime:
            container.Bind<IActionTransactionHelper>().To<ActionTransactionHelper>().InRequestScope();
        }

        private ISession CreateSession(Ninject.Activation.IContext arg)
        {
            var sessionFactory = arg.Kernel.Get<ISessionFactory>();
            if (!CurrentSessionContext.HasBind(sessionFactory))
            {
                var session = sessionFactory.OpenSession();
                CurrentSessionContext.Bind(session);
            }
            return sessionFactory.GetCurrentSession();
        }


        private void ConfigureUserSession(IKernel container)
        {
            var userSession = new UserSession();
            container.Bind<IUserSession>().ToConstant(userSession).InSingletonScope();
            container.Bind<IWebUserSession>().ToConstant(userSession).InSingletonScope();
        }
    }
}


