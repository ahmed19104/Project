using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime DateTime { get; set; }
       
        public ICollection<OrderItem> OrderItems { get; set; }
        public string AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public AppUser AppUser { get; set; }

    }
}
