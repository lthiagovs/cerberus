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

        public ICollection<User> GetUsers()
        {
            return _context.User.OrderBy(user => user.Id).ToList();
        }

        public User? GetUserByID(int ID)
        {
            return this._context.User.FirstOrDefault(user => user.Id == ID);
        }
        
        public User? GetUserByName(string Name)
        {
            return this._context.User.FirstOrDefault(user => user.Name == Name);
        }

        public User? GetUserByLogin(string Email, string Password)
        {
            return this._context.User.FirstOrDefault(user => user.Email == Email && user.Password == Password);
        }

        public bool CreateUser(User user)
        {

            this._context.Add(user);
            return this.Save();

        }

        public bool UpdateUser(User user)
        {
            this._context.Update(user);
            return this.Save();
        }

        public bool DeleteUser(User user)
        {
            this._context.Remove(user);
            return this.Save();
        }

        public bool Save()
        {
            var saved = this._context.SaveChanges();
            return saved > 0 ? true : false;
        }

    }
}
