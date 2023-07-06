using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CinemaWorld.Models
{
    public class NewsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ReleaseDate { get; set; } = null!;
        public int GenreId { get; set; } 
        public string PhotoUrl { get; set; } = null!;
        public string VideoUrl { get; set; } = null!;
    }
}
