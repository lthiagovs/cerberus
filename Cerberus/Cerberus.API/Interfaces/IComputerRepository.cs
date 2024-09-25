using Cerberus.Domain.Models.Machine;

namespace Cerberus.API.Interfaces
{
    public interface IComputerRepository : IRepository
    {

        public ICollection<Computer> GetComputers();

        public Computer? GetComputerByID(int ID);

        public Computer? GetComputerByIP(string IP);

        public bool ComputerExist(int ID);

        public bool CreateComputer(Computer computer);

        public bool UpdateComputer(Computer computer);

        public bool DeleteComputer(Computer computer);

    }

}
