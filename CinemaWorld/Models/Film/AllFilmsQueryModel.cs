using CinemaWorld.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace CinemaWorld.Models.Film
{
    public class AllFilmsQueryModel
    {
        public const int FilmsPerPage = 4;
        public int CurrentPage { get; set; } = 1;

        public IEnumerable<AllFilmViewModel> Films { get; set; } = null!;

        public FilmSorting Sorting { get; set; }

        [Display(Name = "Search by text:")]
        public string? SearchTerm { get; set; }

    }
}
