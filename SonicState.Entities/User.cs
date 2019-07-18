using SonicState.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SonicState.Entities
{
    public class User : BaseModel<int>
    {
        public User()
        {
            Audios = new List<Audio>();
            Playlists = new List<Playlist>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Token { get; set; }
        public virtual ICollection<Audio> Audios { get; set; }
        public virtual ICollection<Playlist> Playlists { get; set; }
    }
}
