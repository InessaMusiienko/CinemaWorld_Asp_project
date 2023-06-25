using CinemaWorld.Contacts;
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

        public FilmController(IFilmService filmService)
        {
            this.filmService = filmService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Catalogue()
        {
            var model = await filmService.GetAllFilmsAsync();
            return View(model);
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
    }
}
