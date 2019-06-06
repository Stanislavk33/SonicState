using SonicState.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace SonicState.Entities
{
    public class Audio : BaseModel<int>
    {
        public Audio() { }

        [Required]
        public string Name { get; set; }

        public double Bpm { get; set; }

        public string Key { get; set; }

        public ChordSequence ChordSequence { get; set; }

        public int ChordSequenceId { get; set; }

    }
}
