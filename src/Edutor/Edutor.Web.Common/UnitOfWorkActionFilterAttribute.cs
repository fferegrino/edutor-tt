using Edutor.Data.Exceptions;
using NHibernate.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace Edutor.Web.Common
{
    public class UnitOfWorkActionFilterAttribute : ActionFilterAttribute
    {
        public virtual IActionTransactionHelper ActionTransactionHelper
        {
            get { return WebContainerManager.Get<IActionTransactionHelper>(); }
        }

        public override bool AllowMultiple
        {
            get { return false; }
        }

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            ActionTransactionHelper.BeginTransaction();
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
#warning This shouldn't be handled here
            try
            {
                ActionTransactionHelper.EndTransaction(actionExecutedContext);
            }
            catch (GenericADOException e)
            {
                ActionTransactionHelper.CloseSession();
                throw new ForeignKeyException("El usuario / estudiante no puede ser eliminado, está en conflicto");
            }
            ActionTransactionHelper.CloseSession();
        }
    }
}
