﻿using Cerberus.API.Interfaces;
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

        public bool CreateVictim(Victim victim)
        {
            throw new NotImplementedException();
        }

        public bool DeleteVictim(Victim victim)
        {
            throw new NotImplementedException();
        }

        public Victim? GetVictimByID(string ID)
        {
            throw new NotImplementedException();
        }

        public Victim? GetVictimByName()
        {
            throw new NotImplementedException();
        }

        public ICollection<Victim> GetVictims()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateVictim(Victim victim)
        {
            throw new NotImplementedException();
        }
    }
}
