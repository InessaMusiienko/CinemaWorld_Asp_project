using System.ComponentModel.DataAnnotations;

namespace CinemaWorld.Models
{
    public class FilmViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Director { get; set; } = null!;

        [Required]
        [StringLength(5000)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public string VideoUrl { get; set; } = null!;

        [Required]
        public decimal Rating { get; set; }

        [Required]
        public string Year { get; set; } = null!;

        [Required]
        public string Country { get; set; } = null!;

        [Required]
        [Range(1, int.MaxValue)]
        public int GenreId { get; set; }

    }
}
