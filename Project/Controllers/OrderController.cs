using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Data.Cart;
using Project.Data.Services;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrdersService _ordersService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IMovicesService _movicesService;
        public OrderController(IOrdersService ordersService, ShoppingCart shoppingCart, IMovicesService movicesService)
        {
            _ordersService = ordersService;
            _shoppingCart = shoppingCart;
            _movicesService = movicesService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddShoppingCart(int id)
        {
            var item = _shoppingCart.GetShoppingCartItemsBy(id); // تأكد إنه بيرجع عنصر واحد
            if (item != null)
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userId))
                {
                    // لو مش مسجل دخول، ارجع للـ Login
                    return RedirectToAction("Login", "Account");
                }
                _shoppingCart.AddItemToCart(item, userId);
            }

            // بدل ما نعمل Redirect للـ Movies، نروح للـ ShoppingCart
            return RedirectToAction(nameof(ShoppingCart));
        }

        public IActionResult RemoveShoppingCart(int id)
        {
            var items = _shoppingCart.GetShoppingCartItemsBy(id);
            if (items != null)
            {
                _shoppingCart.RemoveItemFromCart(items);
            }
            return RedirectToAction(nameof(Index), "Movies");
        }
        public IActionResult ShoppingCart()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var items = _shoppingCart.GetShoppingCardItems(userId);
            _shoppingCart.ShoppingCartItems = items;

            var response = new Data.ViewModel.ShoppingCartVm()
            {
                ShoppingCartItems = items,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(userId)
            };

            return View(response);
        }
        [Authorize]
        public async Task<IActionResult> CompleteOrder()
        {
            
          
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var items = _shoppingCart.GetShoppingCardItems(userId);
            string userEmail = User.FindFirstValue(ClaimTypes.Email);
            await _ordersService.StoreOrderAsync(items, userId, userEmail);
            await _shoppingCart.ClearShoppingCartAsync(userId);
            return View("OrderCompleted");
        }
        public async Task<IActionResult> GetAllOrder()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId,userRole);
            return View(orders);
        }

    }
}
