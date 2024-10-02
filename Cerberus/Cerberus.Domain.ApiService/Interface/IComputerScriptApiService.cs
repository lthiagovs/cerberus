using Cerberus.Domain.Models.Machine;

namespace Cerberus.Domain.ApiService.Interface
{
    public interface IComputerScriptApiService
    {

        public Task<List<ComputerScript>> GetComputerScripts();

        public Task<ComputerScript?> GetComputerScriptByID(int ID);

        public Task<bool> CreateComputerScript(ComputerScript script);

        public Task<bool> UpdateComputerScript(ComputerScript script);

        public Task<bool> DeleteComputerScript(int ID);

    }

}
