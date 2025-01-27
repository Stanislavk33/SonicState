﻿using SonicState.Entities.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SonicState.Entities
{
    public class Audio : BaseModel<string>
    {
        public Audio()
        {
            ChordUnits = new List<ChordUnit>();
            PlaylistAudios = new List<PlaylistAudio>();
        }
        [Required]
        public string Name { get; set; }
        public double Bpm { get; set; }
        public string Key { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ChordUnit> ChordUnits { get; set; }
        public virtual ICollection<PlaylistAudio> PlaylistAudios { get; set; }

        //public string StorageName => Id + Name; 
    }
}
