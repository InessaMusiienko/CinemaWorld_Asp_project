﻿using CinemaWorld.Data.Models;

namespace CinemaWorld.Models.Film
{
    public class DetailsFilmViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Director { get; set; } = null!;
        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
        public string VideoUrl { get; set; } = null!;
        public decimal Rating { get; set; }
        public string Year { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public ICollection<CommentViewModel> Comments { get; set; } = null!;
    }
}
