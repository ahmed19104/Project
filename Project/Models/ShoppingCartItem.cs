namespace Project.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public Movie Movie { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string ShoppingCardId { get; set; } = Guid.NewGuid().ToString();

    }
}
