using Cerberus.Domain.ApiService.Interface;
using Cerberus.Domain.Models.Script;
using Newtonsoft.Json;
using RestSharp;

namespace Cerberus.Domain.ApiService.ApiService
{
    public class LuaResultApiService : ILuaResultApiService
    {

        private readonly RestClient _client;

        public LuaResultApiService(RestClient client)
        {
            this._client = client;
        }

        public async Task<bool> CreateLuaResult(LuaResult luaResult)
        {
            var request = new RestRequest("LuaResult/CreateLuaResult", Method.Post); // Altere para o método apropriado (POST)
            var userSerialized = JsonConvert.SerializeObject(luaResult);

            request.AddParameter("luaResult", userSerialized);

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            bool result = JsonConvert.DeserializeObject<bool>(response.Content); // Remove o operador de nullability aqui

            return result;
        }


        public async Task<List<LuaResult>> GetLuaResults()
        {
            var request = new RestRequest("LuaResult/GetLuaResults", Method.Get); // Altere para o método apropriado (POST)

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            List<LuaResult>? result = JsonConvert.DeserializeObject<List<LuaResult>>(response.Content); // Remove o operador de nullability aqui

            if (result == null)
                throw new Exception("Something went wrong");

            return result;
        }

    }

}
