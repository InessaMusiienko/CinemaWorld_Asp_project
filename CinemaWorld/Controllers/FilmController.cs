using CinemaWorld.Contacts;
using CinemaWorld.Data;
using CinemaWorld.Models;
using CinemaWorld.Models.Film;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace CinemaWorld.Controllers
{
    public class FilmController : BaseController
    {
        private readonly IFilmService filmService;
        private readonly ApplicationDbContext dbContext;

        public FilmController(IFilmService filmService, ApplicationDbContext dbContext)
        {
            this.filmService = filmService;
            this.dbContext = dbContext;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Catalogue([FromQuery] AllFilmsQueryModel query)
        {
            var model = await filmService.GetAllFilmsAsync(query);

            var filmGenres = this.dbContext.Films.Select(f=>f.Genre)
                .Distinct().ToList();

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
            AddFilmViewModel model = await filmService.GetNewAddFilmModelAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewFilm(AddFilmViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await filmService.AddFilmAsync(model);

            return View(model);
        }
    }
}
