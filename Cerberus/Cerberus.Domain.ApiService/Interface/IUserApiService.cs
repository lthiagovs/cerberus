using Cerberus.Domain.Models.Person;

namespace Cerberus.Domain.ApiService.Interface
{
    public interface IUserApiService
    {

        public Task<ICollection<User>> GetUsers();

        public Task<User> GetUserByID(int ID);

        public Task<User> GetUserByName(string name);

        public Task<User> GetUserByLogin(string email, string password);

        public Task<bool> CreateUser(User user);

        public Task<bool> UpdateUser(User user);

        public Task<bool> DeleteUser(int ID);

    }

}
