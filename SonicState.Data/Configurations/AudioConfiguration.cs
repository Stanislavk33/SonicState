using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SonicState.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonicState.Data.Configurations
{
    public class AudioConfiguration : IEntityTypeConfiguration<Audio>
    {
        public void Configure(EntityTypeBuilder<Audio> builder)
        {
            builder.HasMany(c => c.ChordUnits)
                   .WithOne(a => a.Audio)
                   .HasForeignKey(c => c.AudioId);
        }
    }
}
