using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Data.GlobalDataConstraints;

namespace CinemaWorld.Data.Models
{
    public class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(NewsMaxLenght)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLenght)]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(ReleaseDateMaxLenght)]
        public string ReleaseDate { get; set; } = null!;

        [Required]
        [MaxLength(GenreMaxLenght)]
        public string Genre { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string PhotoUrl { get; set; } = null!;

        [Required]
        public string VideoUrl { get; set; } = null!;
    }
}
