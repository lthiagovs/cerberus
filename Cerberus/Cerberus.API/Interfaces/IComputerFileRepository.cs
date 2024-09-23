using Cerberus.Domain.Models.Machine;

namespace Cerberus.API.Interfaces
{
    public interface IComputerFileRepository : IRepository
    {

        public ICollection<ComputerFile> GetComputerFiles(int ComputerID);

        public ComputerFile? GetComputerFileByID(int ID);

        public bool CreateComputerFile(ComputerFile computerFile);

        public bool UpdateComputerFile(ComputerFile computerFile);

        public bool DeleteComputerFile(ComputerFile computerFile);

    }

}
