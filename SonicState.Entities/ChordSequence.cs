using SonicState.Entities.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SonicState.Entities
{
    public class ChordSequence : BaseModel<int>
    {
        public ChordSequence()
        {
            this.Audios = new List<Audio>();
        }

        public string Time { get; set; }

        public string Chord { get; set; }
        
        [Required]
        public virtual ICollection<Audio> Audios { get; set; }

    }
}
