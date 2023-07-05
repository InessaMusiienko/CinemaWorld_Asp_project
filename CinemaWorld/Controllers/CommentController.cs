using CinemaWorld.Contacts;
using CinemaWorld.Data;
using CinemaWorld.Data.Models;
using CinemaWorld.Models;
using CinemaWorld.Services;
using Microsoft.AspNetCore.Mvc;

namespace CinemaWorld.Controllers
{
    public class CommentController : BaseController
    {

        private readonly ApplicationDbContext dbContext;
        private readonly ICommentService commentService;
        private readonly IFilmService filmService;

        public CommentController(ApplicationDbContext dbContext, ICommentService commentService, IFilmService filmService)
        {
            this.dbContext = dbContext;
            this.commentService = commentService;
            this.filmService = filmService;

        }

        [HttpGet]
        public async Task<IActionResult> AddComment(int id)
        {
            var film = await filmService.GetFilmByIdAsync(id);
            if (film == null)
            {
               return RedirectToAction("GetDetails", "Home");
            }
            CommentViewModel model = await commentService.GetNewCommentModelAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CommentViewModel model)
        {
            var film = await filmService.GetFilmByIdAsync(model.Id);

            var comment = new Comment()
            {
                Name = model.Name,
                CommentText = model.CommentText
            };

            await dbContext.Comments.AddAsync(comment);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("GetDetails", "Home");
        }

        public async Task<IActionResult> AllCommentsById(int id)
        {
            var comments = await commentService.GetAllCommentsByIdAsync(id);
            return View(comments);
        }
    }
}
