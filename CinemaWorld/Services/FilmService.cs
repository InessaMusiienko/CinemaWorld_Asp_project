using CinemaWorld.Contacts;
using CinemaWorld.Data;
using CinemaWorld.Data.Models;
using CinemaWorld.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaWorld.Services
{
    public class FilmService : IFilmService
    {
        private readonly ApplicationDbContext dbContext;

        public FilmService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext; 
        }

        public async Task AddFilmToFavouritesAsync(string userId, FilmViewModel film)
        {
            bool isAlreadyAdded = await dbContext.IdentityUserFilms
                .AnyAsync(x => x.UserId == userId && x.FilmId == film.Id);

            if (isAlreadyAdded == false)
            {
                var filmToAdd = new IdentityUserFilm
                {
                    UserId = userId,
                    FilmId = film.Id
                };

                await dbContext.IdentityUserFilms.AddAsync(filmToAdd);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AllFilmViewModel>> GetAllFilmsAsync()
        {
            return await dbContext.Films
                .Select(f => new AllFilmViewModel
                {
                    Id = f.Id, 
                    Name = f.Name,
                    ImageUrl = f.ImageUrl,
                    Description = f.Description,
                    Genre = f.Genre.Name
                }).ToListAsync();
        }

        public async Task<IEnumerable<AllFilmViewModel>> GetFavoutitesAsync(string userId)
        {
            return await dbContext.IdentityUserFilms
            .Where(f => f.UserId == userId)
            .Select(f => new AllFilmViewModel
            {
                Id = f.Film.Id,
                Name = f.Film.Name,
                ImageUrl = f.Film.ImageUrl,
                Description = f.Film.Description,
                Genre = f.Film.Genre.Name
            }).ToListAsync();
        }

        public async Task<FilmViewModel?> GetFilmByIdAsync(int id)
        {
            return await dbContext.Films
                .Where(f => f.Id == id)
                .Select(f => new FilmViewModel
                {
                    Id = f.Id,
                    Name = f.Name,
                    Director = f.Director,
                    Description = f.Description,
                    ImageUrl = f.ImageUrl,
                    VideoUrl = f.VideoUrl,
                    Rating = f.Rating,
                    Year = f.Year,
                    Country = f.Country,
                    GenreId = f.GenreId
                }).FirstOrDefaultAsync();
        }

        public async Task RemoveFilmFromFavouritesAsync(string userId, FilmViewModel film)
        {
            var filmToRemove = await dbContext.IdentityUserFilms
                .FirstOrDefaultAsync(x => x.UserId == userId && x.FilmId == film.Id);

            if (filmToRemove != null)
            {
                dbContext.IdentityUserFilms.Remove(filmToRemove);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
