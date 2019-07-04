using Microsoft.EntityFrameworkCore;
using SonicState.Data.Configurations;
using SonicState.Entities;
using System;

namespace SonicState.Data
{
    public class SonicStateDbContext : DbContext
    {
        public SonicStateDbContext(DbContextOptions<SonicStateDbContext> options) : base(options)
        {

        }

        public DbSet<Audio> Audios { get; set; }

        public DbSet<ChordUnit> ChordSequences { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
           
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
