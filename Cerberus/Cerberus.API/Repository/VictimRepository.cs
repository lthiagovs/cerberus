using Cerberus.API.Interfaces;
using Cerberus.Domain.Models.Person;
using Cerberus.Infrastructure.Data.Context;

namespace Cerberus.API.Repository
{

    public class VictimRepository : IVictimRepository
    {

        public readonly DataContext _context;

        public ICollection<Victim> GetVictims()
        {
            return _context.Victim.OrderBy(victim => victim.Id).ToList();
        }

        public Victim? GetVictimByIp(string IP)
        {

            return _context.Victim.Where(victim => victim.IP.Equals(IP)).FirstOrDefault();

        }

        public VictimRepository(DataContext context)
        {
            this._context = context;
        }


    }
}
