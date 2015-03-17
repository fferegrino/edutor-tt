using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace Edutor.Web.Common
{
    public static class WebContainerManager
    {
        public static IDependencyResolver GetDependencyResolver()
        {
            var depResolver = GlobalConfiguration.Configuration.DependencyResolver;
            if (depResolver == null)
                throw new InvalidOperationException("The dependency resolver has not been set");
            return depResolver;
        }

        public static T Get<T>()
        {
            var service = GetDependencyResolver().GetService(typeof(T));
            if (service == null)
            {
                throw new NullReferenceException(String.Format("No service for  {0} was found", typeof(T).FullName));
            }
            return (T)service;
        }

        public static IEnumerable<T> GetAll<T>()
        {
            var services = GetDependencyResolver().GetServices(typeof(T)).ToList();
            if (!services.Any())
            {
                throw new NullReferenceException(String.Format("No services for  {0} was found", typeof(T).FullName));
            }
            return services.Cast<T>();
        }

    }
}
