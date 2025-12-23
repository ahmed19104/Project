using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Data.Cart
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public AppDbContext _context { get; set; }
        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public Movie GetShoppingCartItemsBy(int id)
        {
            return _context.Movies.FirstOrDefault(n => n.Id == id);
        }
        public List<Models.ShoppingCartItem> GetShoppingCardItems(string userId) { 
           var Shopp= _context.ShoppingCardItems.Include(n => n.Movie).Where(c => c.AppUserId == userId).ToList();
              return Shopp;
        }
        public void AddItemToCart(Movie movie ,string userId)
        {
            var shoppingCardItem = _context.ShoppingCardItems.FirstOrDefault(n => n.Movie.Id == movie.Id&&n.AppUserId==userId);
            if (shoppingCardItem == null)
            {
                shoppingCardItem = new Models.ShoppingCartItem()
                {
                    Movie = movie,
                    Price = movie.Price,
                    Quantity = 1,
                    AppUserId = userId


                };
                _context.ShoppingCardItems.Add(shoppingCardItem);
            }
            else
            {
                shoppingCardItem.Quantity++;
            }
            _context.SaveChanges();
        }


    
    public void RemoveItemFromCart(Movie movie)
        {
            var shoppingCardItem = _context.ShoppingCardItems.FirstOrDefault(n => n.Movie.Id == movie.Id);
            if (shoppingCardItem != null)
            {
                if (shoppingCardItem.Quantity > 1)
                {
                    shoppingCardItem.Quantity--;
                }
                else
                {
                    _context.ShoppingCardItems.Remove(shoppingCardItem);
                }
                _context.SaveChanges();
            }
        }
        public double GetShoppingCartTotal(string userId)
        {
            return _context.ShoppingCardItems
                           .Where(c => c.AppUserId == userId)
                           .Sum(c => c.Price * c.Quantity);
        }

        public async Task ClearShoppingCartAsync(string userId)
        {
            var items = _context.ShoppingCardItems.Where(c => c.AppUserId == userId).ToList();
            _context.ShoppingCardItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
        //public static ShoppingCart GetShoppingCart(IServiceProvider services)
        //{
        //    ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        //    var context = services.GetService<AppDbContext>();
        //    string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
        //    session.SetString("CartId", cartId);
        //    return new ShoppingCart(context) {ShoppingCartId2=cartId};

        //}
     

    }
    
}
