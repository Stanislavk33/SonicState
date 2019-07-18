using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SonicState.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonicState.Data.Configurations
{
   public class UserConfiguration : IEntityTypeConfiguration<User> { 


        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(u => u.Audios)
                  .WithOne(a => a.User)
                  .HasForeignKey(u => u.UserId);

            builder.HasMany(u => u.Playlists)
                 .WithOne(p => p.User)
                 .HasForeignKey(u => u.UserId)
                 .OnDelete(DeleteBehavior.Restrict);
        }

    }

}
