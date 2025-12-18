using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Actor_Movie
    {
        [Key]
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
