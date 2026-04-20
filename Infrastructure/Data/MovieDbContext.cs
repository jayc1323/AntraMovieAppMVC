using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<MovieCrew> MovieCrews { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieGenre>().HasKey(mg => new { mg.MovieId, mg.GenreId });
            modelBuilder.Entity<MovieCast>().HasKey(mc => new { mc.MovieId, mc.CastId });
            modelBuilder.Entity<MovieCrew>().HasKey(mc => new { mc.MovieId, mc.CrewId });
            modelBuilder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });
            modelBuilder.Entity<Review>().HasKey(r => new { r.MovieId, r.UserId });

            modelBuilder.Entity<Movie>().Property(m => m.OverView).HasColumnType("nvarchar(max)");

            modelBuilder.Entity<Review>().Property(r => r.Rating).HasColumnType("decimal(3,1)");

            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Movie).WithMany(m => m.MovieGenres).HasForeignKey(mg => mg.MovieId);
            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Genre).WithMany(g => g.MovieGenres).HasForeignKey(mg => mg.GenreId);

            modelBuilder.Entity<MovieCast>()
                .HasOne(mc => mc.Movie).WithMany(m => m.MovieCasts).HasForeignKey(mc => mc.MovieId);
            modelBuilder.Entity<MovieCast>()
                .HasOne(mc => mc.Cast).WithMany(c => c.MovieCasts).HasForeignKey(mc => mc.CastId);

            modelBuilder.Entity<MovieCrew>()
                .HasOne(mc => mc.Movie).WithMany(m => m.MovieCrews).HasForeignKey(mc => mc.MovieId);
            modelBuilder.Entity<MovieCrew>()
                .HasOne(mc => mc.Crew).WithMany(c => c.MovieCrews).HasForeignKey(mc => mc.CrewId);

            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.User).WithMany(u => u.Purchases).HasForeignKey(p => p.UserId);
            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.Movie).WithMany(m => m.Purchases).HasForeignKey(p => p.MovieId);

            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.User).WithMany(u => u.Favorites).HasForeignKey(f => f.UserId);
            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.Movie).WithMany(m => m.Favorites).HasForeignKey(f => f.MovieId);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User).WithMany(u => u.Reviews).HasForeignKey(r => r.UserId);
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Movie).WithMany(m => m.Reviews).HasForeignKey(r => r.MovieId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId);
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "Admin", LastName = "User", Email = "admin@movieapp.com", HashedPassword = "AQAAAAIAAYagAAAAEHashedPasswordHere", IsLocked = false, DateOfBirth = new DateTime(1990, 1, 1), AccessFailedCount = 0 },
                new User { Id = 2, FirstName = "John", LastName = "Doe", Email = "john@movieapp.com", HashedPassword = "AQAAAAIAAYagAAAAEHashedPasswordHere", IsLocked = false, DateOfBirth = new DateTime(1995, 6, 15), AccessFailedCount = 0 }
            );

        }
    }
}
