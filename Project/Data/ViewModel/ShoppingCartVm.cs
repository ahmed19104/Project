using Project.Models;

namespace Project.Data.ViewModel
{
    public class ShoppingCartVm
    {
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public double ShoppingCartTotal { get; set; }
    }
}
