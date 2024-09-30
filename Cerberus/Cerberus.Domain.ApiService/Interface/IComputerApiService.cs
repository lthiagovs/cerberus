using Cerberus.Domain.Models.Machine;

namespace Cerberus.Domain.ApiService.Interface
{
    public interface IComputerApiService
    {

        public Task<ICollection<Computer>> GetComputers();

        public Task<Computer?> GetComputerByID(int ID);

        public Task<Computer?> GetComputerByIP(string IP);

        public Task<bool> CreateComputer(Computer computer);

        public Task<bool> UpdateComputer(Computer computer);

        public Task<bool> DeleteComputer(int ID);

    }

}
