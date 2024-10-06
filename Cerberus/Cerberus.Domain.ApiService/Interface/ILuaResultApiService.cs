using Cerberus.Domain.Models.Script;

namespace Cerberus.Domain.ApiService.Interface
{
    public interface ILuaResultApiService
    {

        public Task<bool> CreateLuaResult(LuaResult luaResult);

        public Task<List<LuaResult>> GetLuaResults();

        public Task<LuaResult> GetLuaResultByID(int ID);

    }

}
