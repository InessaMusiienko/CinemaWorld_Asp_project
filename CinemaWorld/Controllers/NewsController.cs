using CinemaWorld.Contacts;
using CinemaWorld.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaWorld.Controllers
{   
    public class NewsController : BaseController
    {
        private readonly IFilmService filmService;

        public NewsController(IFilmService filmService)
        {
            this.filmService = filmService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> News()
        {
            var model = await filmService.GetAllNewsAsync();
            return View(model);
        }
    }
}
