using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaWorld.Data.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Director { get; set; } = null!;

        [Required]
        [MaxLength(5000)]
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
        [ForeignKey(nameof(GenreId))]
        public int GenreId { get; set; }
        public Genre Genre { get; set; } = null!;

        public List<IdentityUserFilm> UserFilms { get; set; } = new List<IdentityUserFilm>();
    }
}
