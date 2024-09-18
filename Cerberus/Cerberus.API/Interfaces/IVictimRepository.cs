using Cerberus.Domain.Models.Person;

namespace Cerberus.API.Interfaces
{
    public interface IVictimRepository
    {

        ICollection<Victim> GetVictims();

        Victim? GetVictimByIp(string IP);

    }

}
