using SonicState.Entities;
using SonicState.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SonicState.Contracts.Repositories
{
    public interface IChordUnitRepository : IRepository<ChordUnit>
    {
        ICollection<ChordUnitDetails> GenerateChordSequence(string audioId);
    }
}
