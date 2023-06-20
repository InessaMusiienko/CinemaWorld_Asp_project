using CinemaWorld.Data.Models;

namespace CinemaWorld.Data.Configuration
{
    public class FilmEntityConfiguration
    {
        public ICollection<Film> GenerateFilms()
        {
            ICollection<Film> films = new HashSet<Film>();

            Film firstFilm;
            firstFilm = new Film()
            {
                Id = 1,
                Name = "Black Adam",
                Description = "Nearly 5,000 years after he was bestowed with the almighty powers of the Egyptian gods--and imprisoned just as quickly--Black Adam is freed from his earthly tomb, ready to unleash his unique form of justice on the modern world.",
                Rating = 6,
                Director = "Jaume Collet-Serra",
                Year = "2021",
                GenreId = 5,
                ImageUrl = "https://thesffblog.com/wp-content/uploads/2023/02/blackadam.jpg",
                VideoUrl = "https://www.youtube.com/watch?v=X0tOpBuYasI",
                Country = "United States"
            };
            films.Add(firstFilm);

            Film secondFilm = new Film()
            {
                Id = 2,
                Name = "Fall",
                Description = "Best friends Becky and Hunter find themselves at the top of a 2,000-foot radio tower.",
                Rating = 5,
                Director = "Scott Mann",
                Year = "2022",
                GenreId = 2,
                ImageUrl = "https://www.heavenofhorror.com/wp-content/uploads/2022/08/fall-2022-movie-review-1200x675.jpg",
                VideoUrl = "https://www.youtube.com/watch?v=iSspRSGc4Dk",
                Country = "United States"
            };
            films.Add(secondFilm);

            Film thirdFilm = new Film()
            {
                Id = 3,
                Name = "Luck",
                Description = "The curtain is pulled back on the millennia-old battle between the organizations of good luck and bad luck that secretly affects everyday lives.",
                Rating = 8,
                Director = "Peggy Holmes",
                Year = "2022",
                GenreId = 4,
                ImageUrl = "https://m.media-amazon.com/images/M/MV5BOGYzYWE3YTAtMjg2Ni00MzRkLWEwYWItOWM1MjI3YzhjYTYyXkEyXkFqcGdeQXVyMTUzMTg2ODkz._V1_.jpg",
                VideoUrl = "https://www.youtube.com/watch?v=xSG5UX0EQVg",
                Country = "Spain"
            };
            films.Add(thirdFilm);

            Film forthFilm = new Film()
            {
                Id = 4,
                Name = "The Man From Toronto",
                Description = "The world's deadliest assassin and New York's biggest screw-up are mistaken for each other at an Airbnb rental.",
                Rating = 7,
                Director = "Patrick Hughes",
                Year = "2022",
                GenreId = 3,
                ImageUrl = "https://occ-0-38-33.1.nflxso.net/dnm/api/v6/6gmvu2hxdfnQ55LZZjyzYR4kzGk/AAAABfxgGluO8tGw6B2MGxnAMPK3Yv-AFR7UD9rH50mVD2cXmO8j-j_pEktM278hSC5_rx60GFNcmQxA6A9c9QGEg_D4gNhpzj0uqIgsHXwAZd2CnEl-yj4LlWbTNIckLxlMABV-jA.jpg?r=09c",
                VideoUrl = "https://www.youtube.com/watch?v=urqy8DrcGBs",
                Country = "United States"
            };
            films.Add(forthFilm);

            Film fifthFilm = new Film()
            {
                Id = 5,
                Name = "Thor: Love And Thunder",
                Description = "Thor enlists the help of Valkyrie, Korg and ex-girlfriend Jane Foster to fight Gorr the God Butcher, who intends to make the gods extinct.",
                Rating = 9,
                Director = "Taika Waititi",
                Year = "2022",
                GenreId = 1,
                ImageUrl = "https://media.socastsrm.com/wordpress/wp-content/blogs.dir/460/files/2022/07/banner-thorloveandthunder.jpg",
                VideoUrl = "https://www.youtube.com/watch?v=Go8nTmfrQd8",
                Country = "United States"
            };
            films.Add(fifthFilm);

            return films;
        }
    }
}
