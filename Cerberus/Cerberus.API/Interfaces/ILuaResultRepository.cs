using Cerberus.Domain.Models.Script;

namespace Cerberus.API.Interfaces
{
    public interface ILuaResultRepository
    {

        public ICollection<LuaResult> GetLuaResultsByIP(string IP);

    }

}
