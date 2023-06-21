using CinemaWorld.Data.Models;

namespace CinemaWorld.Models
{
    public class DetailsFilmViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Director { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string VideoUrl { get; set; } = null!;
        public decimal Rating { get; set; }
        public string Year { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Genre { get; set; } = null!;
        //public List<Comment> Comments { get; set; } = null!;
    }
}
