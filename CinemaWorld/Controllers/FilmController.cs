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

using static CinemaWorld.Data.WebConstants;

namespace CinemaWorld.Controllers
{
    public class FilmController : BaseController
    {
        private readonly IFilmService filmService;
        private readonly IGenreService genreService;

        public FilmController(IFilmService filmService, IGenreService genreService)
        {
            this.filmService = filmService;
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

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> AddNewFilm()
        {
            return View(new AddFilmViewModel
            {
                Genres = await genreService.AllGenresAsync()
            });
        }

        [Authorize(Roles = "Admin")]
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

            try
            {
                int filmId = await filmService.AddFilmAsync(model);

                this.TempData[GlobalMessageKey] = "Film was successfully added.";

                return RedirectToAction("GetDetails", "Home", new { id = filmId });
            }
            catch (Exception)
            {
                throw new ArgumentException("Unexpected error");
                model.Genres = await this.genreService.AllGenresAsync();
                return View(model);
            }  
                        
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var film = await filmService.GetFilmByIdAsync(id);

            if (film == null)
            {
                return RedirectToAction("Catalogue", "Film");
            }

            var filmModel = await this.filmService.GetFilmForEditAsync(id);
            filmModel.Genres = await this.genreService.AllGenresAsync();
            return this.View(filmModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, AddFilmViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Genres = await this.genreService.AllGenresAsync();
                return View(model);
            }

            try
            {
                await this.filmService.EditFilmById(id, model);
            }
            catch(Exception)
            {
                throw new ArgumentException("Unexpected error");
                model.Genres = await this.genreService.AllGenresAsync();
                return View(model);
            }

            this.TempData[GlobalMessageKey] = "Film information was updated.";

            return RedirectToAction("Catalogue", "Film");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await this.filmService.GetFilmForDeleteByIdAsync(id);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id, FilmDeleteViewModel filmModel)
        {
            await this.filmService.DeleteFilmByIdAsync(id);

            this.TempData[GlobalMessageKey] = "Film was successfully deleted.";

            return RedirectToAction("Catalogue", "Film");
        }
    }
}
