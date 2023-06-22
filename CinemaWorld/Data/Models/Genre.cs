using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Data.GlobalDataConstraints;

namespace CinemaWorld.Data.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GenreMaxLenght)]
        public string Name { get; set; } = null!;

        public List<Film> Films { get; set; } = new List<Film>();
    }
}
