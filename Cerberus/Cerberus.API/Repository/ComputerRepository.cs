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

        public ICollection<Computer> GetComputers()
        {
            return this._context.Computer.OrderBy(computer => computer.ID).ToList();
        }

        public Computer? GetComputerByID(int ID)
        {
            return this._context.Computer.FirstOrDefault(computer => computer.ID == ID);
        }

        public Computer? GetComputerByIP(string IP)
        {
            return this._context.Computer.FirstOrDefault(computer => computer.IP == IP);
        }

        public bool ComputerExist(int ID)
        {
            return this._context.Computer.Any(computer => computer.ID == ID);
        }

        public bool CreateComputer(Computer computer)
        {
            this._context.Add(computer);
            return this.Save();
        }

        public bool UpdateComputer(Computer computer)
        {
            this._context.Update(computer);
            return this.Save();
        }

        public bool DeleteComputer(Computer computer)
        {
            this._context.Remove(computer);
            return this.Save();
        }

        public bool Save()
        {
            var saved = this._context.SaveChanges();
            return saved > 0 ? true : false;
        }

    }
}
