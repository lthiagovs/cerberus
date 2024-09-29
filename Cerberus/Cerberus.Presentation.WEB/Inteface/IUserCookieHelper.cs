using Cerberus.Domain.Models.Person;

namespace Cerberus.Presentation.WEB.Inteface
{
    public interface IUserCookieHelper
    {

        public void CreateUserCookie(User user);

        public User? GetUserCookie();

        public void RemoveUserCookie();

    }

}
