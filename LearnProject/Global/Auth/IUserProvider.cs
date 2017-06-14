using LearnProject.Model;

namespace LearnProject.Global.Auth
{
    public interface IUserProvider
    {
        User User { get; set; }
    }
}