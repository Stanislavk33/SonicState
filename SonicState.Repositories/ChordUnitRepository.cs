using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SonicState.Contracts.Repositories;
using SonicState.Data;
using SonicState.Entities;
using SonicState.Models.ViewModels;

namespace SonicState.Repositories
{
    public class ChordUnitRepository : DbRepository<ChordUnit>, IChordUnitRepository
    {
        public ChordUnitRepository(SonicStateDbContext db, IMapper mapper) : base(db, mapper)
        {

        }

        public ICollection<ChordUnitDetails> GenerateChordSequence(string audioId)
        {
            if(string.IsNullOrEmpty(audioId)) { throw new ArgumentNullException(); }
            return this.set.Where(c => c.AudioId == audioId).Select(this.mapper.Map<ChordUnitDetails>).OrderBy(c=> c.Time).ToList();
        }
    }
}
