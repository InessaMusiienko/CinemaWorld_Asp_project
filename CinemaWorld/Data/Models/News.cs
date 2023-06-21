using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CinemaWorld.Data.Models
{
    public class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        public DateTime Date { get; set; }

        [Required]
        public string PhotoUrl { get; set; } = null!;
    }
}
