using SonicState.Entities.Common;

namespace SonicState.Entities
{
    public class PlaylistAudio : BaseModel<int>
    {
        public string AudioId { get; set; }

        public virtual Audio Audio { get; set; }

        public int PlaylistId { get; set; }

        public virtual Playlist Playlist { get; set; }

}
}
