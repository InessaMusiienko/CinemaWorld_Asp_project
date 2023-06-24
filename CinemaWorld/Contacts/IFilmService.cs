using CinemaWorld.Models;

namespace CinemaWorld.Contacts
{
    public interface IFilmService
    {
        Task<IEnumerable<AllFilmViewModel>> GetAllFilmsAsync();
        Task<FilmViewModel?> GetFilmByIdAsync(int id);
        Task<IEnumerable<AllFilmViewModel>> GetFavoutitesAsync(string userId);
        Task AddFilmToFavouritesAsync(string userId, FilmViewModel film);
        Task RemoveFilmFromFavouritesAsync(string userId, FilmViewModel film);
        Task<DetailsFilmViewModel?> GetFilmDetailsAsync(int id);
        Task<IEnumerable<NewsViewModel>> GetAllNewsAsync();
        Task <IEnumerable<CommentViewModel?>> GetAllCommentsByIdAsync(int id);
        Task<IEnumerable<FilmByGenreViewModel>> GetFilmByGenreAsync(int genre);

        //Task<CommentFormModel> GetNewCommentModelAsync();


    }
}
