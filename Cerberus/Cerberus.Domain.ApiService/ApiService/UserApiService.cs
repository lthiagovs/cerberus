using Cerberus.Domain.ApiService.Interface;
using Cerberus.Domain.Models.Person;
using Newtonsoft.Json;
using RestSharp;

namespace Cerberus.Domain.ApiService.ApiService
{
    public class UserApiService : IUserApiService
    {

        private readonly RestClient _client;

        public UserApiService()
        {
            this._client = new RestClient("http://localhost:5108/api/User");
        }

        public Task<bool> CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByID()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByLogin(string email, string password)
        {

            var request = new RestRequest("Login", Method.Get); // Altere para o método apropriado (POST)
            request.AddParameter("Email", email);
            request.AddParameter("Password", password);

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            User? user = JsonConvert.DeserializeObject<User>(response.Content); // Remove o operador de nullability aqui

            if (user == null)
                throw new Exception("Something went wrong");

            return user;

        }

        public Task<User> GetUserByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }

}
