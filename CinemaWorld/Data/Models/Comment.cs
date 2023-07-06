using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CinemaWorld.Data.GlobalDataConstraints;

namespace CinemaWorld.Data.Models
{
    public class Comment
    {
        [Key]
        public int commentId { get; set; }

        [Required]
        public string Name { get; set; }

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
