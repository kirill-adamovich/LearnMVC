using System.Security.Principal;
using LearnProject.Model;

namespace LearnProject.Global.Auth
{
    public class UserProvider : IPrincipal
    {
        private UserIdentity userIdentity { get; set; }

        #region IPrincipal Members

        public IIdentity Identity
        {
            get
            {
                return userIdentity;
            }
        }

        public bool IsInRole(string role)
        {
            if (userIdentity.User == null)
            {
                return false;
            }
            return userIdentity.User.InRoles(role);
        }

        #endregion

        public UserProvider(string name, IRepository repository)
        {
            userIdentity = new UserIdentity();
            userIdentity.Init(name, repository);
        }

        public override string ToString()
        {
            return userIdentity.Name;
        }
    }
}