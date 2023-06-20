using CinemaWorld.Contacts;
using CinemaWorld.Models;
using CinemaWorld.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CinemaWorld.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IFilmService filmService;

        public HomeController(IFilmService filmService)
        {
            this.filmService = filmService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = await filmService.GetAllFilmsAsync();
            return View(model);
        }

        public async Task<IActionResult> GetDetails(int id)
        {
            var film = await filmService.GetFilmByIdAsync(id);
            return View(film);            
        }
    }
}