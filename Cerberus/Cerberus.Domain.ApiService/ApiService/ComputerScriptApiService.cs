using Cerberus.Domain.ApiService.Interface;
using Cerberus.Domain.Models.Machine;
using Newtonsoft.Json;
using RestSharp;

namespace Cerberus.Domain.ApiService.ApiService
{
    public class ComputerScriptApiService : IComputerScriptApiService
    {

        private readonly RestClient _client;

        public ComputerScriptApiService(RestClient client)
        {
            this._client = client;
        }

        public async Task<bool> CreateComputerScript(ComputerScript script)
        {
            var request = new RestRequest("ComputerScript/CreateComputerScript", Method.Post);
            var scriptSerialized = JsonConvert.SerializeObject(script);

            request.AddParameter("script", scriptSerialized);

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            bool result = JsonConvert.DeserializeObject<bool>(response.Content);

            return result;
        }

        public async Task<bool> DeleteComputerScript(int ID)
        {
            var request = new RestRequest("ComputerScript/DeleteComputerScript", Method.Delete); // Altere para o método apropriado (POST)

            request.AddParameter("ID", ID);

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            bool result = JsonConvert.DeserializeObject<bool>(response.Content); // Remove o operador de nullability aqui

            return result;
        }

        public async Task<ComputerScript?> GetComputerScriptByID(int ID)
        {

            var request = new RestRequest("ComputerScript/GetComputerScriptByID", Method.Get); // Altere para o método apropriado (POST)
            request.AddParameter("ID", ID);

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            ComputerScript? script = JsonConvert.DeserializeObject<ComputerScript>(response.Content); // Remove o operador de nullability aqui

            if (script == null)
                throw new Exception("Something went wrong");

            return script;

        }

        public async Task<List<ComputerScript>> GetComputerScripts()
        {
            var request = new RestRequest("ComputerScript/GetComputerScripts", Method.Get);

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            List<ComputerScript>? scripts = JsonConvert.DeserializeObject<List<ComputerScript>>(response.Content);

            if (scripts == null)
                throw new Exception("Something went wrong");

            return scripts;
        }

        public async Task<bool> UpdateComputerScript(ComputerScript script)
        {
            var request = new RestRequest("ComputerScript/UpdateComputerScript", Method.Put); // Altere para o método apropriado (POST)
            var computerSerialized = JsonConvert.SerializeObject(script);

            request.AddParameter("script", computerSerialized);

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
