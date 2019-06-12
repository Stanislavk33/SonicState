using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SonicState.Entities;


namespace SonicState.Data.Configurations
{
    public class ChordSequenceConfiguration : IEntityTypeConfiguration<ChordUnit>
    {
        public void Configure(EntityTypeBuilder<ChordUnit> builder)
        {
            
        }
    }
}
