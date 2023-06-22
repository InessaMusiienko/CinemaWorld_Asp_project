using CinemaWorld.Data.Models;

namespace CinemaWorld.Data.Configuration
{
    public class NewsEntityConfiguration
    {
        public ICollection<News> GenerateNews()
        {
            ICollection<News> news = new HashSet<News>();

            News firstNews;
            firstNews = new News()
            {
                Id = 1,
                Title = "Dune: Part two",
                Description = "A boy becomes the Messiah of nomads on a desert planet that has giant worms that protect a commodity called Spice. Spice changes people into travelers, mystics and madmen. What price will he pay to become the new ruler of their universe?",
                Date = DateTime.Now,
                PhotoUrl = "https://m.media-amazon.com/images/M/MV5BN2FjNmEyNWMtYzM0ZS00NjIyLTg5YzYtYThlMGVjNzE1OGViXkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_.jpg"
            };
            news.Add(firstNews);

            News secondNews;
            secondNews = new News()
            {
                Id = 2,
                Title = "Wonka",
                Description = "The story will focus specifically on a young Willy Wonka and how he met the Oompa-Loompas on one of his earliest adventures.",
                Date = DateTime.Now,
                PhotoUrl = "https://pbs.twimg.com/media/FLKj6-paUAA_TGy.jpg"
            };
            news.Add(secondNews);

            return news;

        }
    }
}
