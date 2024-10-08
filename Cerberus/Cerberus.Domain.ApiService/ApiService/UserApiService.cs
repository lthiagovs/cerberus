﻿using Cerberus.Domain.ApiService.Interface;
using Cerberus.Domain.Models.Person;
using Newtonsoft.Json;
using RestSharp;

namespace Cerberus.Domain.ApiService.ApiService
{
    public class UserApiService : IUserApiService
    {

        private readonly RestClient _client;

        public UserApiService(RestClient client)
        {
            this._client = client;
        }

        public async Task<bool> CreateUser(User user)
        {
            var request = new RestRequest("User/CreateUser", Method.Post); // Altere para o método apropriado (POST)
            var userSerialized = JsonConvert.SerializeObject(user);

            request.AddParameter("user", userSerialized);

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            bool result = JsonConvert.DeserializeObject<bool>(response.Content); // Remove o operador de nullability aqui

            return result;
        }

        public async Task<bool> DeleteUser(int ID)
        {
            var request = new RestRequest("User/DeleteUser", Method.Delete); // Altere para o método apropriado (POST)

            request.AddParameter("ID", ID);

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            bool result = JsonConvert.DeserializeObject<bool>(response.Content); // Remove o operador de nullability aqui

            return result;
        }

        public async Task<User> GetUserByID(int ID)
        {

            var request = new RestRequest("User/GetUserByID", Method.Get); // Altere para o método apropriado (POST)
            request.AddParameter("ID", ID);

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

        public async Task<User> GetUserByLogin(string email, string password)
        {

            var request = new RestRequest("User/GetUserByLogin", Method.Get); // Altere para o método apropriado (POST)
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

        public async Task<User> GetUserByName(string name)
        {
            var request = new RestRequest("User/GetUserByName", Method.Get); // Altere para o método apropriado (POST)
            request.AddParameter("Name", name);

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

        public async Task<ICollection<User>> GetUsers()
        {
            var request = new RestRequest("User/GetUsers", Method.Get); // Altere para o método apropriado (POST)

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            List<User>? user = JsonConvert.DeserializeObject<List<User>>(response.Content); // Remove o operador de nullability aqui

            if (user == null)
                throw new Exception("Something went wrong");

            return user;
        }

        public async Task<bool> UpdateUser(User user)
        {
            var request = new RestRequest("User/UpdateUser", Method.Put); // Altere para o método apropriado (POST)
            var userSerialized = JsonConvert.SerializeObject(user);

            request.AddParameter("user", userSerialized);

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            bool result = JsonConvert.DeserializeObject<bool>(response.Content); // Remove o operador de nullability aqui

            return result;
        }


    }

}
