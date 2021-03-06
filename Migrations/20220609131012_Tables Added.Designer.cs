// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using kolokwium.Models;

namespace kolokwium.Migrations
{
    [DbContext(typeof(KolokwiumDbContext))]
    [Migration("20220609131012_Tables Added")]
    partial class TablesAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("kolokwium.Models.Album", b =>
                {
                    b.Property<int>("IdAlbum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlbumName")
                        .HasMaxLength(30)
                        .HasColumnType("int");

                    b.Property<int>("IdMusicLabel")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdAlbum");

                    b.HasIndex("IdMusicLabel");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("kolokwium.Models.MusicLabel", b =>
                {
                    b.Property<int>("IdMusicLabel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdMusicLabel");

                    b.ToTable("MusicLabels");
                });

            modelBuilder.Entity("kolokwium.Models.Musician", b =>
                {
                    b.Property<int>("IdMusician")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NickName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdMusician");

                    b.ToTable("Musicians");
                });

            modelBuilder.Entity("kolokwium.Models.MusicianTrack", b =>
                {
                    b.Property<int>("IdTrack")
                        .HasColumnType("int");

                    b.Property<int>("IdMusician")
                        .HasColumnType("int");

                    b.Property<int>("IdMusicianTrack")
                        .HasColumnType("int");

                    b.HasKey("IdTrack", "IdMusician");

                    b.HasIndex("IdMusician");

                    b.ToTable("MusicianTracks");
                });

            modelBuilder.Entity("kolokwium.Models.Track", b =>
                {
                    b.Property<int>("IdTrack")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Duration")
                        .HasColumnType("real");

                    b.Property<int?>("IdMusicAlbum")
                        .HasColumnType("int");

                    b.Property<string>("TrackName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdTrack");

                    b.HasIndex("IdMusicAlbum");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("kolokwium.Models.Album", b =>
                {
                    b.HasOne("kolokwium.Models.MusicLabel", "MusicLabel")
                        .WithMany("Albums")
                        .HasForeignKey("IdMusicLabel")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("MusicLabel");
                });

            modelBuilder.Entity("kolokwium.Models.MusicianTrack", b =>
                {
                    b.HasOne("kolokwium.Models.Musician", "Musician")
                        .WithMany("MusicianTracks")
                        .HasForeignKey("IdMusician")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("kolokwium.Models.Track", "Track")
                        .WithMany("MusicianTracks")
                        .HasForeignKey("IdTrack")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Musician");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("kolokwium.Models.Track", b =>
                {
                    b.HasOne("kolokwium.Models.Album", "Album")
                        .WithMany("Tracks")
                        .HasForeignKey("IdMusicAlbum")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.Navigation("Album");
                });

            modelBuilder.Entity("kolokwium.Models.Album", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("kolokwium.Models.MusicLabel", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("kolokwium.Models.Musician", b =>
                {
                    b.Navigation("MusicianTracks");
                });

            modelBuilder.Entity("kolokwium.Models.Track", b =>
                {
                    b.Navigation("MusicianTracks");
                });
#pragma warning restore 612, 618
        }
    }
}
