using Edutor.Common;
using Edutor.Common.Logging;
using Edutor.Common.Security;
using Edutor.Data.Entities;
using Edutor.Web.Common;
using log4net;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Edutor.Web.Api.Securitiy
{
    public interface IBasicSecurityService
    {
        bool SetPrincipal(char type, string passwordOrToken, int userId = 0);
    }

    public class BasicSecurityService : IBasicSecurityService
    {
        private readonly ILog _log;


        public BasicSecurityService(ILogManager logManager)
        {
            _log = logManager.GetLog(typeof(BasicSecurityService));
        }

        public virtual ISession Session { get { return WebContainerManager.Get<ISession>(); } }

        public bool SetPrincipal(char type, string passwordOrToken, int userId = 0)
        {

            IPrincipal principal = null;
            if (type == 'T')
            {
                Student student = GetStudent(passwordOrToken);
                if (student == null || (principal = GetPrincipal(student)) == null)
                {
                    _log.DebugFormat("No se pudo autenticar {0}", userId);
                    return false;
                }

                Thread.CurrentPrincipal = principal;
                if (HttpContext.Current.User != null)
                {
                    HttpContext.Current.User = principal;
                }
            }
            else if (type == 'S')
            {
                User user = GetUser(userId, passwordOrToken);
                if (user == null || (principal = GetPrincipal(user)) == null)
                {
                    _log.DebugFormat("No se pudo autenticar al usuario {0}", userId);
                    return false;
                }

                Thread.CurrentPrincipal = principal;
                if (HttpContext.Current.User != null)
                {
                    HttpContext.Current.User = principal;
                }
            }


            return true;
        }

        public virtual IPrincipal GetPrincipal(User user)
        {
            var identity = new GenericIdentity(user.UserId.ToString(), Constants.SchemeTypes.Basic);

            identity.AddClaim(new Claim(ClaimTypes.Role,
                user.Position == User.AdministrativePosition ? Constants.RoleNames.Administrator : Constants.RoleNames.Teacher));
            identity.AddClaim(new Claim(Constants.CustomClaimTypes.SchoolUserId, user.UserId.ToString()));

            return new ClaimsPrincipal(identity);
        }

        public virtual IPrincipal GetPrincipal(Student student)
        {
            var identity = new GenericIdentity(student.Tutor.UserId.ToString(), Constants.SchemeTypes.Basic);

            identity.AddClaim(new Claim(ClaimTypes.Role, Constants.RoleNames.Tutor));
            identity.AddClaim(new Claim(Constants.CustomClaimTypes.StudentId, student.StudentId.ToString()));
            identity.AddClaim(new Claim(Constants.CustomClaimTypes.TutorId, student.Tutor.UserId.ToString()));

            return new ClaimsPrincipal(identity);
        }

        public virtual User GetUser(int userId, string password)
        {
            string p = PasswordHasher.HashAndSaltPassword(password);
            return Session.QueryOver<User>().Where(user => user.UserId == userId && user.Password == p).SingleOrDefault();
        }

        private Student GetStudent(string token)
        {
            return Session.QueryOver<Student>().Where(student => student.Token == (token)).SingleOrDefault();
        }
    }
}
