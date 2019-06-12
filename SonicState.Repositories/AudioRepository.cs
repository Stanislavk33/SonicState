using SonicState.Contracts.Repositories;
using SonicState.Data;
using SonicState.Entities;
using System;

namespace SonicState.Repositories
{
    public class AudioRepository : DbRepository<Audio>, IAudioRepository
    {
        public AudioRepository(SonicStateDbContext db) : base(db)
        {

        }

        
    }
}
