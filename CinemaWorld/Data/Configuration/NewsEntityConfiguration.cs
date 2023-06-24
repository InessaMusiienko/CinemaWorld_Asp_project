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

            News thirdNews = new News()
            {
                Id = 3,
                Title = "Next Goal Wins",
                Description = "The story of the infamously terrible American Samoa soccer team, known for a brutal 2001 FIFA match they lost 31-0.",
                Date = DateTime.Now,
                PhotoUrl = "https://syn.org.au/app/uploads/Next-Goal-Wins-Movie-Poster-Large.jpg"
            };
            news.Add(thirdNews);

            News fourthNews = new News()
            {
                Id = 4,
                Title = "The Hunger Games: The Ballad of Songbirds and Snakes",
                Description = "Coriolanus Snow mentors and develops feelings for the female District 12 tribute during the 10th Hunger Games.",
                Date = DateTime.Now,
                PhotoUrl = "https://static.titlovi.com/img/0313/313021-tt10545296.jpg"
            };
            news.Add(fourthNews);

            return news;

        }
    }
}
