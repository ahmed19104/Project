using Project.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Actor: IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ProfilePictureURL { get; set; }
        public ICollection<Actor_Movie> Actor_Movie { get; set; }
    }
}
