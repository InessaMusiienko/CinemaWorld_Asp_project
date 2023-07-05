using CinemaWorld.Models;

namespace CinemaWorld.Contacts
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentViewModel?>> GetAllCommentsByIdAsync(int id);
        Task<CommentViewModel> GetNewCommentModelAsync(int id);
    }
}
