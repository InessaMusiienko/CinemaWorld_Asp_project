using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Data.GlobalDataConstraints;


namespace CinemaWorld.Models
{
    public class CommentFormModel
    {
        [Required]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght,
            ErrorMessage = "Name should be at least {2} characters long.")]
        public string Name { get; set; }

        [Required]
        [StringLength(CommentMaxlenght, MinimumLength = CommmentMinLenght, 
            ErrorMessage = "Comment should be at least {2} characters long.")]
        public string CommentText { get; set; } = null!;

        //[Display(Name = "Film")]  public string Film

    }
}
