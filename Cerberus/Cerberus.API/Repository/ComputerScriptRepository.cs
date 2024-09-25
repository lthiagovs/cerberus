using Cerberus.API.Interfaces;
using Cerberus.Domain.Models.Machine;
using Cerberus.Infrastructure.Data.Context;

namespace Cerberus.API.Repository
{
    public class ComputerScriptRepository : IComputerScriptRepository
    {

        private readonly DataContext _context;

        public ComputerScriptRepository(DataContext context)
        {
            this._context = context;
        }

        public ICollection<ComputerScript> GetComputerScripts()
        {
            return this._context.ComputerScript.OrderBy(script => script.ID).ToList();  
        }

        public ComputerScript? GetComputerScriptByID(int ID)
        {
            return this._context.ComputerScript.FirstOrDefault(script => script.ID == ID);
        }

        public bool ComputerScriptExist(int ID)
        {
            return this._context.ComputerScript.Any(script => script.ID == ID);
        }
        public bool CreateComputerScript(ComputerScript computerScript)
        {
            this._context.Add(computerScript);
            return this.Save();
        }

        public bool UpdateComputerScript(ComputerScript computerScript)
        {
            this._context.Update(computerScript);
            return this.Save();
        }

        public bool DeleteComputerScript(ComputerScript computerScript)
        {
            this._context.Remove(computerScript);
            return this.Save();
        }

        public bool Save()
        {
            var saved = this._context.SaveChanges();
            return saved > 0 ? true : false;
        }

    }
}
