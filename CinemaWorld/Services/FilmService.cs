using CinemaWorld.Contacts;
using CinemaWorld.Data;
using CinemaWorld.Data.Models;
using CinemaWorld.Models;
using CinemaWorld.Models.Film;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace CinemaWorld.Services
{
    public class FilmService : IFilmService
    {
        private readonly ApplicationDbContext dbContext;

        public FilmService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext; 
        }

        public async Task<int> AddFilmAsync(AddFilmViewModel model)
        {
            Film film = new Film()
            {
                Name = model.Name,
                Director = model.Director,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                VideoUrl = model.VideoUrl,
                Rating = model.Rating,
                Year = model.Year,
                Country = model.Country,
                GenreId = model.GenreId
            };

            await dbContext.Films.AddAsync(film);
            await dbContext.SaveChangesAsync();

            return film.Id;
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

        public async Task DeleteFilmByIdAsync(int id)
        {
            var filmToDelete = await this.dbContext.Films
                .FirstAsync(f => f.Id == id);

            dbContext.Remove(filmToDelete);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditFilmById(int id, AddFilmViewModel model)
        {
            var film = await this.dbContext.Films
                .FirstAsync(f => f.Id == id);

            film.Name = model.Name;
            film.Director = model.Director;
            film.Description = model.Description;
            film.ImageUrl = model.ImageUrl;
            film.VideoUrl = model.VideoUrl;
            film.Rating = model.Rating;
            film.Year = model.Year;
            film.Country = model.Country;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllFilmViewModel>> GetAllFilmsAsync([FromQuery] AllFilmsQueryModel query)
        {
            var filmQuery = this.dbContext.Films.AsQueryable();
                        
            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                filmQuery = filmQuery.Where(f => f.Name.ToLower().Contains(query.SearchTerm));
            }

            filmQuery = query.Sorting switch
            {
                FilmSorting.RatingAscending => filmQuery.OrderBy(f => f.Rating),
                FilmSorting.RatingDescending => filmQuery.OrderByDescending(f => f.Rating),
                _ => filmQuery.OrderByDescending(f=>f.Id)
            };

            var totalFilms = filmQuery.Count();
            query.TotalFilms = totalFilms;
                        
            return await filmQuery
                .Skip((query.CurrentPage -1) * query.FilmsPerPage)
                .Take(query.FilmsPerPage)
                .Select(f => new AllFilmViewModel
                {
                    Id = f.Id, 
                    Name = f.Name,
                    ImageUrl = f.ImageUrl,
                    Rating = f.Rating,
                    Country = f.Country,
                    Description = f.Description,
                    Genre = f.Genre.Name
                }).ToListAsync();
        }

        public async Task<IEnumerable<NewsViewModel>> GetAllNewsAsync()
        {
            return await dbContext.News
                .Select(n => new NewsViewModel
                {
                    Id = n.Id,
                    Title = n.Title,
                    Description = n.Description,
                    ReleaseDate = n.ReleaseDate,
                    PhotoUrl = n.PhotoUrl,
                    VideoUrl = n.VideoUrl,
                    Genre = n.Genre.Name
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

        public async Task<IEnumerable<FilmByGenreViewModel>> GetFilmByGenreAsync(int genre)
        {
            return await dbContext.Films
                .Where(f => f.GenreId == genre)
                .Select(f => new FilmByGenreViewModel
                {
                    Id = f.Id,
                    Name = f.Name,
                    ImageUrl = f.ImageUrl,
                    Description = f.Description,
                    Year = f.Year,
                    Country = f.Country,
                    Genre = f.Genre.Name
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

        public async Task<DetailsFilmViewModel?> GetFilmDetailsAsync(int id)
        {
            return await dbContext.Films
                .Where(f => f.Id == id)
                .Select(f => new DetailsFilmViewModel
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
                    Genre = f.Genre.Name,
                    Comments = f.Comments.Select(c=> new CommentViewModel
                    {
                        Id= c.commentId,
                        Name = c.Name,
                        CommentText = c.CommentText,
                        CretedOn = c.CretedOn,
                        FilmId = c.FilmId
                    }).ToList()
                }).FirstOrDefaultAsync();
        }

        public async Task<FilmDeleteViewModel> GetFilmForDeleteByIdAsync(int Id)
        {
            var film = await dbContext.Films
                .FirstAsync(f => f.Id == Id);

            return new FilmDeleteViewModel()
            {
                Name = film.Name,
                Description = film.Description,
                ImageUrl = film.ImageUrl
            };
        }

        public async Task<AddFilmViewModel> GetFilmForEditAsync(int id)
        {
            Film film = await dbContext.Films
                .Include(f => f.Genre)
                .FirstAsync(f => f.Id == id);

            return new AddFilmViewModel
            {
                Name = film.Name,
                Director = film.Director,
                Description = film.Description,
                ImageUrl = film.ImageUrl,
                VideoUrl = film.VideoUrl,
                Rating = film.Rating,
                Year = film.Year,
                Country = film.Country,
                GenreId = film.GenreId
            };
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

        public async Task<IEnumerable<AllFilmViewModel>> TakeThreeFilmsAsync()
        {
            return await dbContext.Films
                .OrderByDescending(f=>f.Id)
                .Take(3)
                .Select(f => new AllFilmViewModel
                {
                    Id = f.Id,
                    Name = f.Name,
                    Director = f.Director,
                    ImageUrl = f.ImageUrl,
                    Year = f.Year,
                    Country = f.Country,
                    Description = f.Description,
                    Rating = f.Rating,
                    Genre = f.Genre.Name
                }).ToListAsync();
        }

        //private static IEnumerable<FilmViewModel> GetFilm(IQuerable<Film> film) =>
                //    dbContext.Films
                //.Select(f => new AllFilmViewModel
                //{
                //    Id = f.Id,
                //    Name = f.Name,
                //    Director = f.Director,
                //    ImageUrl = f.ImageUrl,
                //    Year = f.Year,
                //    Country = f.Country,
                //    Description = f.Description,
                //    Rating = f.Rating,
                //    Genre = f.Genre.Name
                         //}).ToListAsync();
}
}
