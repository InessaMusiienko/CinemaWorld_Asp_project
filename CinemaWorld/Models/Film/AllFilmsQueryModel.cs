using CinemaWorld.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace CinemaWorld.Models.Film
{
    public class AllFilmsQueryModel
    {
        public AllFilmsQueryModel()
        {
            this.CurrentPage = 1;
            this.FilmsPerPage = 4;
        }
        [Display(Name ="Films on page")]
        public int FilmsPerPage { get; set; }
        public int CurrentPage { get; set; } 

        public int TotalFilms { get; set; } 

        public IEnumerable<AllFilmViewModel> Films { get; set; } = null!;

        [Display(Name = "Sort by")]
        public FilmSorting Sorting { get; set; }

        [Display(Name = "Search by text")]
        public string? SearchTerm { get; set; }

    }
}
