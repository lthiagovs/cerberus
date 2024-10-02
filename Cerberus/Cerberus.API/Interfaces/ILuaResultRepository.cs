using Cerberus.Domain.Models.Script;

namespace Cerberus.API.Interfaces
{
    public interface ILuaResultRepository : IRepository
    {

        public ICollection<LuaResult> GetLuaResults();

        public ICollection<LuaResult> GetLuaResultsByIP(string IP);

        public bool CreateLuaResult(LuaResult luaResult);


    }

}
