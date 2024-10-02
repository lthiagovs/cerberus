using Cerberus.API.Interfaces;
using Cerberus.Domain.Models.Script;
using Cerberus.Infrastructure.Data.Context;

namespace Cerberus.API.Repository
{
    public class LuaResultRepository : ILuaResultRepository
    {

        private readonly DataContext _context;

        public LuaResultRepository(DataContext context)
        {
            this._context = context;
        }

        public ICollection<LuaResult> GetLuaResults()
        {

            return this._context.LuaResult.ToList();

        }

        public ICollection<LuaResult> GetLuaResultsByIP(string IP)
        {
            return this._context.LuaResult.Where(result => result.IP == IP).OrderBy(result => result.Time).ToList();
        }

        public bool CreateLuaResult(LuaResult luaResult)
        {
            this._context.Add(luaResult);
            return this.Save();
        }

        public bool Save()
        {
            var saved = this._context.SaveChanges();
            return saved > 0 ? true : false;
        }

    }

}
