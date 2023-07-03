using CinemaWorld.Models;

namespace CinemaWorld.Contacts
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreViewModel>> AllGenresAsync();

        Task<bool> ExistByIdAsync(int id);
    }
}
