using SonicState.Contracts.Repositories;
using SonicState.Contracts.Services;
using SonicState.Models.ViewModels;
using System.Collections.Generic;

namespace SonicState.Services
{
    public class ChordService : IChordService
    {
        private readonly IChordUnitRepository chordUnitRepository;

        public ChordService(IChordUnitRepository chordUnitRepository)
        {
            this.chordUnitRepository = chordUnitRepository;
        }

        public ICollection<ChordUnitDetails> GetChordSequence(string audioId)
        {

            return chordUnitRepository.GenerateChordSequence(audioId);
        }
    }
}
