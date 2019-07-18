﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SonicState.Data;

namespace SonicState.Data.Migrations
{
    [DbContext(typeof(SonicStateDbContext))]
    [Migration("20190715170959_AddedTokenPropertyToUser")]
    partial class AddedTokenPropertyToUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SonicState.Entities.Audio", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Bpm");

                    b.Property<string>("Key");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Audios");
                });

            modelBuilder.Entity("SonicState.Entities.ChordUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AudioId");

                    b.Property<string>("Chord");

                    b.Property<double>("Time");

                    b.HasKey("Id");

                    b.HasIndex("AudioId");

                    b.ToTable("ChordSequences");
                });

            modelBuilder.Entity("SonicState.Entities.Playlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("SonicState.Entities.PlaylistAudio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AudioId");

                    b.Property<int>("PlaylistId");

                    b.HasKey("Id");

                    b.HasIndex("AudioId");

                    b.HasIndex("PlaylistId");

                    b.ToTable("PlaylistAudio");
                });

            modelBuilder.Entity("SonicState.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Token");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SonicState.Entities.Audio", b =>
                {
                    b.HasOne("SonicState.Entities.User", "User")
                        .WithMany("Audios")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SonicState.Entities.ChordUnit", b =>
                {
                    b.HasOne("SonicState.Entities.Audio", "Audio")
                        .WithMany("ChordUnits")
                        .HasForeignKey("AudioId");
                });

            modelBuilder.Entity("SonicState.Entities.Playlist", b =>
                {
                    b.HasOne("SonicState.Entities.User", "User")
                        .WithMany("Playlists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SonicState.Entities.PlaylistAudio", b =>
                {
                    b.HasOne("SonicState.Entities.Audio", "Audio")
                        .WithMany("PlaylistAudios")
                        .HasForeignKey("AudioId");

                    b.HasOne("SonicState.Entities.Playlist", "Playlist")
                        .WithMany("PlaylistAudios")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}