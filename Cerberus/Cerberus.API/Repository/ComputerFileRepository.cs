using Cerberus.API.Interfaces;
using Cerberus.Domain.Models.Machine;
using Cerberus.Infrastructure.Data.Context;

namespace Cerberus.API.Repository
{
    public class ComputerFileRepository : IComputerFileRepository
    {

        private readonly DataContext _context;

        public ComputerFileRepository(DataContext context)
        {
            this._context = context;
        }

        public bool CreateComputerFile(ComputerFile computerFile)
        {
            throw new NotImplementedException();
        }

        public bool DeleteComputerFile(ComputerFile computerFile)
        {
            throw new NotImplementedException();
        }

        public ComputerFile? GetComputerFileByID(int ID)
        {
            throw new NotImplementedException();
        }

        public ICollection<ComputerFile> GetComputerFiles(int ComputerID)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateComputerFile(ComputerFile computerFile)
        {
            throw new NotImplementedException();
        }
    }
}
