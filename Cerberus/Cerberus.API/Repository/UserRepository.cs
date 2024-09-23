using Cerberus.API.Interfaces;
using Cerberus.Domain.Models.Person;
using Cerberus.Infrastructure.Data.Context;

namespace Cerberus.API.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            this._context = context;
        }

        public bool CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public User? GetUserByID(int ID)
        {
            throw new NotImplementedException();
        }

        public User? GetUserByLogin(string Login, string Password)
        {
            throw new NotImplementedException();
        }

        public User? GetUserByName(string Name)
        {
            throw new NotImplementedException();
        }

        public ICollection<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
