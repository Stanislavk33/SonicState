using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SonicState.Entities;

namespace SonicState.Data.Configurations
{
    public class PlaylistAudioConfiguration : IEntityTypeConfiguration<PlaylistAudio>
    {
        public void Configure(EntityTypeBuilder<PlaylistAudio> builder)
        {
            builder.HasKey(pa => new { pa.AudioId, pa.PlaylistId });

            builder.HasOne(pa => pa.Audio)
                .WithMany(a => a.PlaylistAudios)
                .HasForeignKey(pa => pa.AudioId);

            builder.HasOne(pa => pa.Playlist)
                .WithMany(p => p.PlaylistAudios)
                .HasForeignKey(pa => pa.PlaylistId);
        }

    }

}
