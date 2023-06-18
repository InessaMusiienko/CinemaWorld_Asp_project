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

            builder.Entity<Film>()
                .HasData(new Film()
                {
                    Id = 1,
                    Name = "Black Adam",
                    Description = "Nearly 5,000 years after he was bestowed with the almighty powers of the Egyptian gods--and imprisoned just as quickly--Black Adam is freed from his earthly tomb, ready to unleash his unique form of justice on the modern world.",
                    Rating = 6,
                    Director = "Jaume Collet-Serra",
                    Year = "2021",
                    GenreId = 5,
                    ImageUrl = "https://thesffblog.com/wp-content/uploads/2023/02/blackadam.jpg",
                    VideoUrl = "https://www.youtube.com/watch?v=X0tOpBuYasI",
                    Country = "United States"
                });

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
               Name = "Biography"
           },
           new Genre()
           {
               Id = 3,
               Name = "Children"
           },
           new Genre()
           {
               Id = 4,
               Name = "Crime"
           },
           new Genre()
           {
               Id = 5,
               Name = "Fantasy"
           });
            builder.Entity<IdentityUserFilm>().HasKey(x => new { x.FilmId, x.UserId });
            builder.Entity<Film>().Property(p => p.Rating).HasPrecision(18, 2);
            base.OnModelCreating(builder);
        }

        public DbSet<Film> Films { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<IdentityUserFilm> IdentityUserFilms { get; set; } = null!;
    }
}