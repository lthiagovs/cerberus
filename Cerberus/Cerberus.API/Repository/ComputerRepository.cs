using Cerberus.API.Interfaces;
using Cerberus.Domain.Models.Machine;
using Cerberus.Infrastructure.Data.Context;

namespace Cerberus.API.Repository
{
    public class ComputerRepository : IComputerRepository
    {

        private readonly DataContext _context;

        public ComputerRepository(DataContext context)
        {

            this._context = context;
        }

        public bool CreateComputer(Computer computer)
        {
            throw new NotImplementedException();
        }

        public bool DeleteComputer(Computer computer)
        {
            throw new NotImplementedException();
        }

        public Computer? GetComputerByID(string ID)
        {
            throw new NotImplementedException();
        }

        public Computer? GetComputerByIP(string IP)
        {
            throw new NotImplementedException();
        }

        public ICollection<Computer> GetComputers()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateComputer(Computer computer)
        {
            throw new NotImplementedException();
        }
    }
}
