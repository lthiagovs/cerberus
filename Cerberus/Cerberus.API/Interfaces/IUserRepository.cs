using Cerberus.Domain.Models.Person;

namespace Cerberus.API.Interfaces
{
    public interface IUserRepository : IRepository
    {

        public ICollection<User> GetUsers();

        public User? GetUserByID(int ID);

        public User? GetUserByName(string Name);

        public User? GetUserByLogin(string Login, string Password);

        public bool CreateUser(User user);

        public bool UpdateUser(User user);

        public bool DeleteUser(User user);

    }
}
