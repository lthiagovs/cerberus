using Cerberus.Domain.ApiService.Interface;
using Cerberus.Domain.Models.Machine;
using Newtonsoft.Json;
using RestSharp;

namespace Cerberus.Domain.ApiService.ApiService
{
    public class ComputerApiService : IComputerApiService
    {

        private readonly RestClient _client;

        public ComputerApiService(RestClient client)
        {
            this._client = client;
        }

        public async Task<bool> CreateComputer(Computer computer)
        {
            var request = new RestRequest("Computer/CreateComputer", Method.Post); // Altere para o método apropriado (POST)
            var computerSerialized = JsonConvert.SerializeObject(computer);

            request.AddParameter("computer", computerSerialized);

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            bool result = JsonConvert.DeserializeObject<bool>(response.Content); // Remove o operador de nullability aqui

            return result;
        }

        public async Task<bool> DeleteComputer(int ID)
        {
            var request = new RestRequest("Computer/DeleteComputer", Method.Delete); // Altere para o método apropriado (POST)

            request.AddParameter("ID", ID);

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            bool result = JsonConvert.DeserializeObject<bool>(response.Content); // Remove o operador de nullability aqui

            return result;
        }

        public async Task<Computer?> GetComputerByID(int ID)
        {

            var request = new RestRequest("Computer/GetComputerByID", Method.Get); // Altere para o método apropriado (POST)
            request.AddParameter("ID", ID);

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            Computer? computer = JsonConvert.DeserializeObject<Computer>(response.Content); // Remove o operador de nullability aqui

            if (computer == null)
                throw new Exception("Something went wrong");

            return computer;

        }

        public async Task<Computer?> GetComputerByIP(string IP)
        {

            var request = new RestRequest("User/Login", Method.Get); // Altere para o método apropriado (POST)
            request.AddParameter("IP", IP);

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            Computer? computer = JsonConvert.DeserializeObject<Computer>(response.Content); // Remove o operador de nullability aqui

            if (computer == null)
                throw new Exception("Something went wrong");

            return computer;

        }

        public async Task<ICollection<Computer>> GetComputers()
        {
            var request = new RestRequest("Computer/GetComputers", Method.Get); // Altere para o método apropriado (POST)

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            List<Computer>? computers = JsonConvert.DeserializeObject<List<Computer>>(response.Content); // Remove o operador de nullability aqui

            if (computers == null)
                throw new Exception("Something went wrong");

            return computers;
        }

        public async Task<bool> UpdateComputer(Computer computer)
        {
            var request = new RestRequest("Computer/UpdateComputer", Method.Put); // Altere para o método apropriado (POST)
            var computerSerialized = JsonConvert.SerializeObject(computer);

            request.AddParameter("computer", computerSerialized);

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
