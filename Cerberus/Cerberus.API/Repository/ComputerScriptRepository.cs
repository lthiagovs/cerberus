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

        public bool CreateComputerScript(ComputerScript computerScript)
        {
            throw new NotImplementedException();
        }

        public bool DeleteComputerScript(ComputerScript computerScript)
        {
            throw new NotImplementedException();
        }

        public ComputerScript? GetComputerScriptByID(int ID)
        {
            throw new NotImplementedException();
        }

        public ICollection<ComputerScript> GetComputerScripts()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateComputerScript(ComputerScript computerScript)
        {
            throw new NotImplementedException();
        }
    }
}
