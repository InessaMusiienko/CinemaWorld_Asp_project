using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaWorld.Data.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string CommentText { get; set; } = null!;

        [Required]
        public DateTime CretedOn { get; set; }

        [Key]
        [ForeignKey(nameof(FilmId))]
        public string FilmId { get; set; } = null!;        
        public Film Film { get; set; } = null!;
    }
}
