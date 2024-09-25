using Cerberus.Domain.Models.Machine;
using Cerberus.Domain.Models.Person;
using Microsoft.EntityFrameworkCore;
namespace Cerberus.Infrastructure.Data.Context
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Victim> Victim { get; set; }

        public DbSet<Computer> Computer { get; set; }

        public DbSet<ComputerFile> ComputerFile {  get; set; }

        public DbSet<ComputerScript> ComputerScript {  get; set; }

        public DbSet<User> User { get; set; }

    }

}
