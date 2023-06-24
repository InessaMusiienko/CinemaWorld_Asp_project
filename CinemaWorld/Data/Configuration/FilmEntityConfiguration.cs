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

            Film sixthFilm = new Film()
            {
                Id = 6,
                Name = "Avatar: The Way of Water",
                Description = "Jake Sully lives with his newfound family formed on the extrasolar moon Pandora. Once a familiar threat returns to finish what was previously started, Jake must work with Neytiri and the army of the Na'vi race to protect their home.",
                Rating = 7,
                Director = "James Cameron",
                Year = "2022",
                GenreId = 1,
                ImageUrl = "https://images.thedirect.com/media/tag_thumbnail/avatar-the-way-of-water_VyIagyn.png",
                VideoUrl = "https://www.youtube.com/watch?v=d9MyW72ELq0",
                Country = "United States"
            };
            films.Add(sixthFilm);

            Film seventhFilm = new Film()
            {
                Id = 7,
                Name = "The Flash",
                Description = "Barry Allen uses his super speed to change the past, but his attempt to save his family creates a world without super heroes, forcing him to race for his life in order to save the future.",
                Rating = 7,
                Director = "Andy Muschietti",
                Year = "2023",
                GenreId = 1,
                ImageUrl = "https://images.lesindesradios.fr/fit-in/1100x2000/filters:format(webp)/radios/voltage/importrk/news/original/5bd72d70386b79.39893365.jpg",
                VideoUrl = "https://www.youtube.com/watch?v=hebWYacbdvc",
                Country = "United States"
            };
            films.Add(seventhFilm);

            Film eighthFilm = new Film()
            {
                Id = 8,
                Name = "The Little Mermaid",
                Description = "A young mermaid makes a deal with a sea witch to trade her beautiful voice for human legs so she can discover the world above water and impress a prince.",
                Rating = 6,
                Director = "Rob Marshall",
                Year = "2023",
                GenreId = 5,
                ImageUrl = "https://staticc.sportskeeda.com/editor/2023/05/564f7-16838889721714-1920.jpg",
                VideoUrl = "https://www.youtube.com/watch?v=kpGo2_d3oYE",
                Country = "United States"
            };
            films.Add(eighthFilm);

            Film ninethFilm = new Film()
            {
                Id = 9,
                Name = "Elemental",
                Description = "Follows Ember and Wade, in a city where fire-, water-, land- and air-residents live together.",
                Rating = 8,
                Director = "Peter Sohn",
                Year = "2023",
                GenreId = 4,
                ImageUrl = "https://www.hindustantimes.com/ht-img/img/2023/06/15/1600x900/Screenshot_2023-06-15_185111_1686835310989_1686835321066.png",
                VideoUrl = "https://www.youtube.com/watch?v=hXzcyx9V0xw",
                Country = "United States"
            };
            films.Add(ninethFilm);

            Film tenthFilm = new Film()
            {
                Id = 10,
                Name = "A Man Called Otto",
                Description = "Follows Ember and Wade, in a city where fire-, water-, land- and air-residents live together.",
                Rating = 9,
                Director = "Marc Forster",
                Year = "2022",
                GenreId = 3,
                ImageUrl = "https://images.hive.blog/p/7b4bio5hobgsatHMcQi2An2xspUC9U8FN8S3zY2E1vASRo1iFqpQAq3pNovHQRTLdqZrNuUDLNzyVCLBqeQ1yW3A2PCWdjsJbN2vcfXkFWqk5TV7At3kyErc74YWka29A1Y7DTVu8QGMC4gfdx8VJKmfvK4A?format=match&mode=fit",
                VideoUrl = "https://www.youtube.com/watch?v=eFYUX9l-m5I",
                Country = "United States"
            };
            films.Add(tenthFilm);

            return films;
        }
    }
}
