using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Actor_Movie
    {
    public int Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int ActorId { get; set; }   // ← أضف السطر ده
        public Actor Actor { get; set; }   // ← أضف السطر ده (كان موجود بس للتأكيد)
    }
}