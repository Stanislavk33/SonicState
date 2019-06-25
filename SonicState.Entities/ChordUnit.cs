using SonicState.Entities.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SonicState.Entities
{
    public class ChordUnit : BaseModel<int>
    {
        public ChordUnit()
        {
            
        }

        public double Time { get; set; }

        public string Chord { get; set; }
        
        public int AudioId { get; set; }
        public virtual Audio Audio { get; set; }

    }
}
