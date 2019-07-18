using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SonicState.Entities;

namespace SonicState.Data.Configurations
{
    public class AudioConfiguration : IEntityTypeConfiguration<Audio>
    {
        public void Configure(EntityTypeBuilder<Audio> builder)
        {
            builder.HasMany(c => c.ChordUnits)
                   .WithOne(a => a.Audio)
                   .HasForeignKey(c => c.AudioId);

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedNever();
        }
    }
}
