using Project.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Producert
    {
        [Key]
        public int ProducerId { get; set; }
        public string FullName { get; set; }
        public string ProfilePictureURL { get; set; }
        public ICollection<Movie> Movies { get; set; }
        
    }
}
