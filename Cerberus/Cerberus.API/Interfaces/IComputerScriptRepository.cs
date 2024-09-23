using Cerberus.Domain.Models.Machine;

namespace Cerberus.API.Interfaces
{
    public interface IComputerScriptRepository : IRepository
    {

        public ICollection<ComputerScript> GetComputerScripts();

        public ComputerScript? GetComputerScriptByID(int ID);

        public bool CreateComputerScript(ComputerScript computerScript);

        public bool UpdateComputerScript(ComputerScript computerScript);

        public bool DeleteComputerScript(ComputerScript computerScript);

        public bool Save();

    }

}
