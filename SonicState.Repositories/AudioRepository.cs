using AutoMapper;
using SonicState.Contracts.Repositories;
using SonicState.Data;
using SonicState.Entities;
using SonicState.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SonicState.Repositories
{
    public class AudioRepository : DbRepository<Audio>, IAudioRepository
    {
        public AudioRepository(SonicStateDbContext db, IMapper mapper) : base(db, mapper)
        {

        }

        public IEnumerable<AudioDetails> GetAll()
        {
            return set.Select(this.mapper.Map<AudioDetails>);
        }
    }
}
