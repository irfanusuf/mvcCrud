using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvcRegistrations.Models;

namespace mvcRegistrations.Controllers
{
    public class CartController : Controller
    {
        private readonly registrationsDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CartController(registrationsDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var cartItems = _context.CartModels
                .Where(c => c.UserId == user.Id)
                .Include(c => c.Product) // Include product details
                                         //  .AsNoTracking() // perfoemance upgrade ....
                .ToList();

            return View(cartItems);
        }




        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId)
        {
            var user = await _userManager.GetUserAsync(User); //here i m geeting the logged in user
            if (user == null)
            {
                return RedirectToAction("Login", "Account");   // ager na kheen teli gow karun login 
            }

            var cartItem = new CartModel
            {
                UserId = user.Id,      // cart may product add kernay kay time UserId property ko iterate kerna 
                ProductId = productId,   //post probably this will come from frontend 
                Quantity = 1         // post probably this will come from frontend 
            };

            _context.CartModels.Add(cartItem);
            await _context.SaveChangesAsync();

            return RedirectToAction("Cart", "Cart");
        }

    }
}

