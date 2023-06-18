using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaWorld.Data.Models
{
    public class IdentityUserFilm
    {
        [Key]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        [Key]
        public int FilmId { get; set; }

        [ForeignKey(nameof(FilmId))]
        public Film Film { get; set; } = null!;
    }
}
