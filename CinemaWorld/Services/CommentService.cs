using CinemaWorld.Contacts;
using CinemaWorld.Data;
using CinemaWorld.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaWorld.Services
{
    public class CommentService: ICommentService
    {
        private readonly ApplicationDbContext dbContext;

        public CommentService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<CommentViewModel?>> GetAllCommentsByIdAsync(int id)
        {
            return await dbContext.Comments
                .Where(c => c.FilmId == id)
                .Select(c => new CommentViewModel
                {
                    Id = c.commentId,
                    Name = c.Name,
                    CommentText = c.CommentText,
                    CretedOn = DateTime.Now,
                    FilmId = c.FilmId
                }).ToListAsync();
        }

        public async Task<CommentViewModel> GetNewCommentModelAsync(int id)
        {
            var film = await dbContext.Films
                .FirstAsync(f => f.Id == id);

            var model = new CommentViewModel
            {
                CretedOn = DateTime.Now,
                FilmId = id
            };

            return model;
        }
    }
}
