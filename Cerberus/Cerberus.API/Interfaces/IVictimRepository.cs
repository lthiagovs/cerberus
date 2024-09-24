using Cerberus.Domain.Models.Person;

namespace Cerberus.API.Interfaces
{
    public interface IVictimRepository : IRepository
    {

        public ICollection<Victim> GetVictims();

        public Victim? GetVictimByID(int ID);

        public Victim? GetVictimByName(string Name);

        public bool CreateVictim(Victim victim);

        public bool UpdateVictim(Victim victim);

        public bool DeleteVictim(Victim victim);

    }

}
