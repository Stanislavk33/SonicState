using System.Collections.Generic;

namespace SonicState.Models.ViewModels
{
    public class AudioChords
    {
        public virtual ICollection<ChordUnitDetails> ChordUnits { get; set; }
    }
}
