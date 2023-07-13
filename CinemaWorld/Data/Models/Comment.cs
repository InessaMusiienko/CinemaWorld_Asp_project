using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CinemaWorld.Data.GlobalDataConstraints;

namespace CinemaWorld.Data.Models
{
    public class Comment
    {
        [Key]
        public Guid CommentId { get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(CommentMaxlenght)]
        public string CommentText { get; set; } = null!;

        [Required]
        public DateTime CretedOn { get; set; }

        [Key]
        [ForeignKey(nameof(FilmId))]
        public int FilmId { get; set; }  
        public Film Film { get; set; } = null!;
    }
}
