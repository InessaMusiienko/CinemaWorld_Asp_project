using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Data.GlobalDataConstraints;

namespace CinemaWorld.Models.Film
{
    public class AddFilmViewModel
    {

        [Required]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght,
            ErrorMessage = "Name should be at least {2} characters long.")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DirectorMaxLenght, MinimumLength = DirectorMinLenght,
            ErrorMessage = "Director name should be at least {2} characters long.")]
        public string Director { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLenght, MinimumLength = DescriptionMinLenght,
            ErrorMessage = "Description should be at least {2} characters long.")]
        public string Description { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        public string ImageUrl { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        public string VideoUrl { get; set; } = null!;

        [Required]
        public decimal Rating { get; set; }

        [Required]
        [StringLength(YearMaxLenght, MinimumLength = YearMinLenght,
            ErrorMessage = "Year should be {2} characters long.")]
        public string Year { get; set; } = null!;

        [Required]
        [StringLength(CountryMaxLenght, MinimumLength = CountryMinLenght,
            ErrorMessage = "Country should be at least {2} characters long.")]
        public string Country { get; set; } = null!;

        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        public IEnumerable<GenreViewModel> Genres { get; set; } = new HashSet<GenreViewModel>();

    }
}
