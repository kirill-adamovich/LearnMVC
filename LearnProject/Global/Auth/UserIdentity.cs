using System.Security.Principal;
using LearnProject.Model;

namespace LearnProject.Global.Auth
{

    public class UserIdentity: IIdentity, IUserProvider
    {

        public User User { get; set; }

        public string AuthenticationType
        {
            get
            {
                return typeof(User).ToString();
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return User != null;
            }
        }

        public string Name
        {
            get
            {
                if (User != null)
                {
                    return User.Email;
                }
                //иначе аноним
                return "anonym";
            }
        }

        public void Init(string email, IRepository repository)
        {
            if (!string.IsNullOrEmpty(email))
            {
                User = repository.GetUser(email);
            }
        }
    }
}