using CinemaWorld.Models;
using CinemaWorld.Models.Film;
using Microsoft.AspNetCore.Mvc;

namespace CinemaWorld.Contacts
{
    public interface IFilmService
    {
        Task<IEnumerable<AllFilmViewModel>> GetAllFilmsAsync([FromQuery] AllFilmsQueryModel query);
        Task<FilmViewModel?> GetFilmByIdAsync(int id);
        Task<IEnumerable<AllFilmViewModel>> GetFavoutitesAsync(string userId);
        Task AddFilmToFavouritesAsync(string userId, FilmViewModel film);
        Task RemoveFilmFromFavouritesAsync(string userId, FilmViewModel film);
        Task<DetailsFilmViewModel?> GetFilmDetailsAsync(int id);
        Task<IEnumerable<NewsViewModel>> GetAllNewsAsync();
        Task<IEnumerable<FilmByGenreViewModel>> GetFilmByGenreAsync(int genre);
        Task<int> AddFilmAsync(AddFilmViewModel model);
        Task<IEnumerable<AllFilmViewModel>> TakeThreeFilmsAsync();
        Task<FilmDeleteViewModel> GetFilmForDeleteByIdAsync (int Id);
        Task<AddFilmViewModel> GetFilmForEditAsync(int id);
        Task EditFilmById(int id, AddFilmViewModel model);
        Task DeleteFilmByIdAsync(int id);



    }
}
