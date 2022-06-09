using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace kolokwium.Models
{
    public class KolokwiumDbContext : DbContext
    {
        public KolokwiumDbContext()
        {
        }
        public KolokwiumDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<MusicianTrack> MusicianTracks { get; set; }
        public virtual DbSet<Musician> Musicians { get; set; }
        public virtual DbSet<MusicLabel> MusicLabels { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<Album>(e => {
                e.HasKey(e => e.IdAlbum);
                e.Property(e => e.AlbumName).HasMaxLength(30).IsRequired();
                e.Property(e => e.PublishDate).IsRequired();
                
                e.HasOne(e => e.MusicLabel)
                .WithMany(e => e.Albums)
                .HasForeignKey(e => e.IdMusicLabel)
                .OnDelete(DeleteBehavior.ClientCascade);
                
                
            });

            modelBuilder.Entity<Musician>(e => {
                e.HasKey(e => e.IdMusician);
                e.Property(e => e.FirstName).HasMaxLength(30).IsRequired();
                e.Property(e => e.LastName).HasMaxLength(50).IsRequired();
                e.Property(e => e.NickName).HasMaxLength(20);
                
            });

            modelBuilder.Entity<Track>(e => {
                e.HasKey(e => e.IdTrack);
                e.Property(e => e.TrackName).HasMaxLength(20).IsRequired();
                e.Property(e => e.Duration).IsRequired();
                
                e.HasOne(e => e.Album)
                .WithMany(e => e.Tracks)
                .HasForeignKey(e => e.IdMusicAlbum)
                .OnDelete(DeleteBehavior.ClientCascade);
            });

            modelBuilder.Entity<MusicianTrack>(e => {
                e.HasKey(e => new {e.IdTrack, e.IdMusician});

                e.HasOne(e => e.Track)
                .WithMany(e => e.MusicianTracks)
                .HasForeignKey(e => e.IdTrack)
                .OnDelete(DeleteBehavior.ClientCascade);

                e.HasOne(e => e.Musician)
                .WithMany(e => e.MusicianTracks)
                .HasForeignKey(e => e.IdMusician)
                .OnDelete(DeleteBehavior.ClientCascade);
            });

            modelBuilder.Entity<MusicLabel>(e => {
                e.HasKey(e => e.IdMusicLabel);
                e.Property(e => e.Name).HasMaxLength(50).IsRequired();

            });


        }
        
    }
}