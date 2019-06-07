using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SonicState.Entities;


namespace SonicState.Data.Configurations
{
    public class ChordSequenceConfiguration : IEntityTypeConfiguration<ChordSequence>
    {
        public void Configure(EntityTypeBuilder<ChordSequence> builder)
        {
            builder.HasMany(c => c.Audios)
                .WithOne(a => a.ChordSequence)
                .HasForeignKey(a => a.ChordSequenceId);
        }
    }
}
