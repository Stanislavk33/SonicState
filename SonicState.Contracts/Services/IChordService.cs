using SonicState.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonicState.Contracts.Services
{
    public interface IChordService
    {
        ICollection<ChordUnitDetails> GetChordSequence(string audioId);
    }
}
