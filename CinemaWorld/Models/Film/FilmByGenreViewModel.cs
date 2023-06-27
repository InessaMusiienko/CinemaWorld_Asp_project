namespace CinemaWorld.Models.Film
{
    public class FilmByGenreViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Year { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Genre { get; set; } = null!;
    }
}
