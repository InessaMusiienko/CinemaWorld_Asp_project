using CinemaWorld.Contacts;
using CinemaWorld.Data;
using CinemaWorld.Data.Models;
using CinemaWorld.Models;
using CinemaWorld.Models.Film;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace CinemaWorld.Controllers
{
    public class FilmController : BaseController
    {
        private readonly IFilmService filmService;
        private readonly IGenreService genreService;
        private readonly ApplicationDbContext dbContext;

        public FilmController(IFilmService filmService, ApplicationDbContext dbContext, IGenreService genreService)
        {
            this.filmService = filmService;
            this.dbContext = dbContext;
            this.genreService = genreService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Catalogue([FromQuery] AllFilmsQueryModel query)
        {
            var model = await filmService.GetAllFilmsAsync(query);

            return View(new AllFilmsQueryModel
            {
                
                Films = model,
                SearchTerm = query.SearchTerm,
                Sorting = query.Sorting
            });
        }

        public async Task<IActionResult> Mine()
        {
            var model = await filmService.GetFavoutitesAsync(GetUserId());
            return View(model);
        }

        public async Task<IActionResult> AddToFavourites(int id)
        {
            var film = await filmService.GetFilmByIdAsync(id);
            if (film == null)
            {
                return RedirectToAction(nameof(Catalogue));
            }

            var userId = GetUserId();

            await filmService.AddFilmToFavouritesAsync(userId, film);
            return RedirectToAction(nameof(Mine));
        }

        public async Task<IActionResult> RemoveFromFavourites(int id)
        {
            var film = await filmService.GetFilmByIdAsync(id);

            if (film == null)
            {
                return RedirectToAction(nameof(Mine));
            }

            var userId = GetUserId();

            await filmService.RemoveFilmFromFavouritesAsync(userId, film);
            return RedirectToAction(nameof(Mine));
        }

        [AllowAnonymous]
        public async Task<IActionResult> FilmByGenre (int id)
        {
            var film = await filmService.GetFilmByIdAsync(id);

            if (film == null)
            {
                return RedirectToAction(nameof(Mine));
            }

            var genre = film.GenreId;

            var model = await filmService.GetFilmByGenreAsync(genre);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddNewFilm()
        {
            return View(new AddFilmViewModel
            {
                Genres = await genreService.AllGenresAsync()
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddNewFilm(AddFilmViewModel model)
        {
            bool genreExist = await this.genreService.ExistByIdAsync(model.GenreId);
            if (!genreExist)
            {
                throw new ArgumentException("Selected genre doesn't exist");
            }
            if (ModelState.IsValid == false)
            {
                model.Genres = await genreService.AllGenresAsync();
                return View(model);
            }

            await filmService.AddFilmAsync(model);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var genres = await dbContext.Genres
               .Select(c => new GenreViewModel
               {
                   Id = c.Id,
                   Name = c.Name
               }).ToListAsync();

            var film = dbContext.Films
                .Where(f => f.Id == id).FirstOrDefault();

            return View(new AddFilmViewModel
            {
                    Name = film.Name,
                    Director = film.Director,
                    Description = film.Description,
                    ImageUrl = film.ImageUrl,
                    VideoUrl = film.VideoUrl,
                    Rating = film.Rating,
                    Year = film.Year,
                    Country = film.Country,
                    GenreId = film.GenreId,
                    Genres = genres
            });
        }

        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, string name, string director, string description, string imageUrl, string videoUrl, 
        //    decimal rating, string year, string country, AddFilmViewModel model)
        //{
        //    if (ModelState.IsValid == false)
        //    {
        //        return View(model);
        //    }

        //    var film = dbContext.Films.Find(id);

        //    film.Name = name;
        //    film.Director = director;
        //    film.Description = description;
        //    film.ImageUrl = imageUrl;
        //    film.VideoUrl = videoUrl;
        //    film.Rating = rating;
        //    film.Year = year;
        //    film.Country = country;

        //    await dbContext.Films.AddAsync(film);
        //    await dbContext.SaveChangesAsync();
        //}
        
    }
}
