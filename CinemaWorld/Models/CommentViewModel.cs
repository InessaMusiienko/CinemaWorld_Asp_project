namespace CinemaWorld.Models
{
    public class CommentViewModel
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string CommentText { get; set; } = null!;
        public DateTime CretedOn { get; set; }
        public int FilmId { get; set; } 
    }
}
