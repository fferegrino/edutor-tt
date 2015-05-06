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
using AQP = Edutor.Web.Api.QueryProcessing;

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
            container.Bind<IDateTime>().To<DateTimeAdapter>().InSingletonScope();
        }

        private void ConfigureAutoMapper(IKernel container)
        {
            container.Bind<TM.IAutoMapper>().To<TM.AutoMapperAdapter>().InSingletonScope();

            container.Bind<TM.IAutoMapperTypeConfigurator>()
                .To<AMC.NewUserToUserEntityAutoMapperTypeConfigurator>().InSingletonScope();
            container.Bind<TM.IAutoMapperTypeConfigurator>()
                .To<AMC.NewUserToSchoolUserEntityAutoMapperTypeConfigurator>().InSingletonScope();
            container.Bind<TM.IAutoMapperTypeConfigurator>()
                .To<AMC.SchoolUserEntityToSimpleSchoolUserModelAutoMapperTypeConfigurator>().InSingletonScope();
        }

        private void ConfigureQueryProcessors(IKernel container)
        {
            container.Bind<QueryProcessors.IAddUserQueryProcessor>().To<SqlProcessors.AddUserQueryProcessor>().InRequestScope();
            container.Bind<QueryProcessors.IAddSchoolUserQueryProcessor>().To<SqlProcessors.AddSchoolUserQueryProcessor>().InRequestScope();
            container.Bind<QueryProcessors.IGetSchoolUsersQueryProcessors>().To<SqlProcessors.GetSchoolUsersQueryProcesors>().InRequestScope();

            container.Bind<AQP.IGetSchoolUsersQueryProcessor>().To<AQP.SchoolUsersQueryProcessor>().InRequestScope();
            container.Bind<AMP.IPostSchoolUserMaintenanceProcessor>().To<AMP.PostSchoolUserMaintenanceProcessor>().InRequestScope();
        }

        private void ConfigureLog4Net(IKernel container)
        {
            XmlConfigurator.Configure();
            var logManager = new LogManagerAdapter();
            container.Bind<ILogManager>().ToConstant(logManager);
        }

        private void ConfigureNHibernate(IKernel container)
        {
            var sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey("edutorDb")))
                .CurrentSessionContext("web")
                // TODO: add new mappings
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Mapping.UserMap>())
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


        private void ConfigureUserSession(IKernel container) {
            var userSession = new UserSession();
            container.Bind<IUserSession>().ToConstant(userSession).InSingletonScope();
            container.Bind<IWebUserSession>().ToConstant(userSession).InSingletonScope();
        }
    }
}

