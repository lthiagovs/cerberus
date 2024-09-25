using Cerberus.API.Interfaces;
using Cerberus.Domain.Models.Person;
using Cerberus.Infrastructure.Data.Context;

namespace Cerberus.API.Repository
{

    public class VictimRepository : IVictimRepository
    {

        public readonly DataContext _context;

        public VictimRepository(DataContext context)
        {
            this._context = context;
        }

        public ICollection<Victim> GetVictims()
        {
            return this._context.Victim.OrderBy(victim => victim.ID).ToList();
        }
        
        public Victim? GetVictimByID(int ID)
        {
            return this._context.Victim.FirstOrDefault(victim => victim.ID == ID);
        }

        public Victim? GetVictimByName(string Name)
        {
            return this._context.Victim.FirstOrDefault(victim => victim.Name == Name);
        }

        public bool VictimExist(int ID)
        {
            return this._context.Victim.Any(victim => victim.ID == ID);
        }

        public bool CreateVictim(Victim victim)
        {
            this._context.Add(victim);
            return this.Save();
        }

        public bool UpdateVictim(Victim victim)
        {
            this._context.Update(victim);
            return this.Save();
        }

        public bool DeleteVictim(Victim victim)
        {
            this._context.Remove(victim);
            return this.Save();
        }

        public bool Save()
        {
            var saved = this._context.SaveChanges();
            return saved > 0 ? true : false;
        }

    }
}
