namespace CinemaWorld.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string CommentText { get; set; } = null!;
        public DateTime CretedOn { get; set; }
        public int FilmId { get; set; } 
    }
}
