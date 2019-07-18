using AutoMapper;
using SonicState.Contracts;
using SonicState.Data;
using SonicState.Entities;
 
namespace SonicState.Repositories
{
    public class PlaylistRepository : DbRepository<Playlist>, IPlaylistRepository
    {
        public PlaylistRepository(SonicStateDbContext db, IMapper mapper) : base(db, mapper)
        {

        }
        
    }
}
