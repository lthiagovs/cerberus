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

        public ICollection<ComputerFile> GetComputerFiles(int ID)
        {
            return this._context.ComputerFile.Where(file => file.ComputerID == ID).OrderBy(file => file.ID).ToList();
        }

        public ComputerFile? GetComputerFileByID(int ID)
        {
            return this._context.ComputerFile.FirstOrDefault(file => file.ID == ID);
        }

        public bool ComputerFileExist(int ID)
        {
            return this._context.ComputerFile.Any(file => file.ID == ID);
        }

        public bool CreateComputerFile(ComputerFile computerFile)
        {
            this._context.Add(computerFile);
            return this.Save();
        }

        public bool UpdateComputerFile(ComputerFile computerFile)
        {
            this._context.Update(computerFile);
            return this.Save();
        }

        public bool DeleteComputerFile(ComputerFile computerFile)
        {
            this._context.Remove(computerFile);
            return this.Save();
        }

        public bool Save()
        {
            var saved = this._context.SaveChanges();
            return saved > 0 ? true : false;
        }

    }
}
