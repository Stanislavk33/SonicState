using SonicState.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SonicState.Entities
{
    public class Playlist : BaseModel<int>
    {
        public Playlist()
        {
            PlaylistAudios = new List<PlaylistAudio>();
        }
        [Required]
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<PlaylistAudio> PlaylistAudios { get; set; }

    }
}
