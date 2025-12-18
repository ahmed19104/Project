using Project.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Movie: IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }
        //Relationships
        public ICollection<Actor_Movie> Actor_Movie { get; set; }
        //Cinema
        [ForeignKey("Cinema")]
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }
        //Producer
        [ForeignKey("Producer")]
        public int ProducerId { get; set; }
        public Producert Producer { get; set; }
    }
}
