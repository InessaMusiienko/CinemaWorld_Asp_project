using CinemaWorld.Contacts;
using CinemaWorld.Models;
using CinemaWorld.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
            var model = await filmService.TakeThreeFilmsAsync();
            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> GetDetails(int id)
        {
            var film = await filmService.GetFilmDetailsAsync(id);
            return View(film);            
        }

        [Authorize]
        public IActionResult Chat()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400 || statusCode == 404)
            {
                return this.View("Error404");
            }
            return View();
        }
    }
}