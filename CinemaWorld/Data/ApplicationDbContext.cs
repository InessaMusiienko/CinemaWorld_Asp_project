using CinemaWorld.Data.Configuration;
using CinemaWorld.Data.Models;
using MessagePack.Formatters;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CinemaWorld.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating (ModelBuilder builder)
        {
            builder
           .Entity<Genre>()
           .HasData(new Genre()
           {
               Id = 1,
               Name = "Action"
           },
           new Genre()
           {
               Id = 2,
               Name = "Thriller"
           },
           new Genre()
           {
               Id = 3,
               Name = "Comedy"
           },
           new Genre()
           {
               Id = 4,
               Name = "Animation"
           },
           new Genre()
           {
               Id = 5,
               Name = "Fantasy"
           },
           new Genre()
           {
               Id = 6,
               Name = "Drama"
           });
            

            var films = new FilmEntityConfiguration();
            builder.Entity<Film>()
                .HasData(films.GenerateFilms());

            var news = new NewsEntityConfiguration();
            builder.Entity<News>()
                .HasData(news.GenerateNews());

            builder.Entity<IdentityUserFilm>().HasKey(x => new { x.FilmId, x.UserId });
            builder.Entity<Comment>().HasKey(x => new { x.commentId, x.FilmId });
            builder.Entity<Film>().Property(p => p.Rating).HasPrecision(18, 2);
            base.OnModelCreating(builder);
        }

        public DbSet<Film> Films { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<News> News { get; set; } = null!;
        public DbSet<IdentityUserFilm> IdentityUserFilms { get; set; } = null!;
    }
}