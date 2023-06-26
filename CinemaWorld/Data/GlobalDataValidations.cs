namespace CinemaWorld.Data
{
    public class GlobalDataConstraints
    {
        //Film
        public const int NameMaxLenght = 50;
        public const int NameMinLenght = 3;

        public const int DirectorMaxLenght = 30;
        public const int DirectorMinLenght = 2;

        public const int DescriptionMaxLenght = 5000;
        public const int DescriptionMinLenght = 10;

        public const int YearMaxLenght = 5;
        public const int YearMinLenght = 4;

        public const int CountryMaxLenght = 56;
        public const int CountryMinLenght = 4;

        //Genre
        public const int GenreMaxLenght = 20;
        public const int GenreMinLenght = 4;

        //News
        public const int NewsMaxLenght = 100;
        public const int NewsMinLenght = 5;

        public const int ReleaseDateMaxLenght = 15;

        public const int ImageUrlMaxLength = 2048;

        //Comment
        public const int CommentMaxlenght = 100;
        public const int CommmentMinLenght = 5;
    }
}
