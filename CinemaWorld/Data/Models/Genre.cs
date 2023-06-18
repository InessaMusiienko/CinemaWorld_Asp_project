using System.ComponentModel.DataAnnotations;

namespace CinemaWorld.Data.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        public List<Film> Films { get; set; } = new List<Film>();
    }
}
