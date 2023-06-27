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

        public async Task AddFilmAsync(AddFilmViewModel model)
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
                Country = model.Country
            };

            await dbContext.Films.AddAsync(film);
            await dbContext.SaveChangesAsync();
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

        public async Task<IEnumerable<CommentViewModel?>> GetAllCommentsByIdAsync(int id)
        {
            return await dbContext.Comments
                .Where(c => c.FilmId == id.ToString())
                .Select(c => new CommentViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    CommentText = c.CommentText,
                    CretedOn = DateTime.Now,
                    Film = c.FilmId
                }).ToListAsync();
        }

        public async Task<IEnumerable<AllFilmViewModel>> GetAllFilmsAsync([FromQuery] SearchFilmsViewModel query)
        {
            var filmQuery = this.dbContext.Films.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Genre))
            {
                filmQuery = filmQuery.Where(f => f.Genre.ToString() == query.Genre);
            }
            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                filmQuery = filmQuery.Where(f => f.Name.ToLower().Contains(query.SearchTerm));
            }

            filmQuery = query.Sorting switch
            {
                FilmSorting.DateCreated => filmQuery.OrderByDescending(f => f.Id),
                FilmSorting.Rating => filmQuery.OrderByDescending(f => f.Rating),
                FilmSorting.Country  or _ => filmQuery.OrderBy(f=>f.Country)
            };

            var totalFilms = filmQuery.Count();
            return await filmQuery
                .Skip((query.CurrentPage -1) * SearchFilmsViewModel.FilmsPerPage)
                .Take(SearchFilmsViewModel.FilmsPerPage)
                .OrderBy(f=>f.Id)
                .Select(f => new AllFilmViewModel
                {
                    Id = f.Id, 
                    Name = f.Name,
                    ImageUrl = f.ImageUrl,
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
                    Genre = n.Genre,
                    PhotoUrl = n.PhotoUrl,
                    VideoUrl = n.VideoUrl
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
                        Id= c.Id,
                        Name = c.Name,
                        CommentText = c.CommentText,
                        CretedOn = c.CretedOn,
                        Film = c.Film.Name
                    }).ToList()
                }).FirstOrDefaultAsync();
        }

        public async Task<AddFilmViewModel> GetNewAddFilmModelAsync()
        {
            var genres = await dbContext.Genres
                .Select(c => new GenreViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();

            var model = new AddFilmViewModel
            {
                Genres = genres
            };

            return model;
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
                .OrderBy(f=>f.Rating)
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
    }
}
