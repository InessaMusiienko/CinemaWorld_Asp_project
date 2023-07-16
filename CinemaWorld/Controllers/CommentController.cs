using CinemaWorld.Contacts;
using CinemaWorld.Data;
using CinemaWorld.Data.Models;
using CinemaWorld.Models;
using CinemaWorld.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var film = await filmService.GetFilmByIdAsync(int.Parse(model.Id));

            var comment = new Comment()
            {
                Name = model.Name,
                CommentText = model.CommentText,
                FilmId = int.Parse(model.Id)
            };

            await dbContext.Comments.AddAsync(comment);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("GetDetails", "Home", new {id = model.Id});
        }

        public async Task<IActionResult> AllCommentsById(int id)
        {
            var comments = await commentService.GetAllCommentsByIdAsync(id);
            return View(comments);
        }

        //[Authorize(Roles = "Admin")]
        
        public async Task<IActionResult> DeleteComment(string Id)
        {
            var commentToDelete = await dbContext.Comments.FirstOrDefaultAsync(x => x.CommentId == Guid.Parse(Id));
            var film = commentToDelete.FilmId;

            if (commentToDelete != null)
            {
                dbContext.Comments.Remove(commentToDelete);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("GetDetails", "Home", new {id = film});
        }
    }
}
