using GameShop.Models;
using GameShopProject.Data;
using GameShopProject.Exceptions;
using GameShopProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameShopProject.Services.Implementations
{
    public class CartService: ICartService
    {
        private readonly GameShopDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartService(GameShopDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
    
        public const string CartSessionKey = "CartId";
        public string ShoppingCartId { get; set; }
    
        public void AddToCard(int id)
        {
            // Retrieve the product from the database.           
            ShoppingCartId = GetCartId();
            var cartItem = _context.CartItems.SingleOrDefault(c => c.CartId == ShoppingCartId && c.GameId == id);

            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    ItemId = Guid.NewGuid().ToString(),
                    GameId = id,
                    CartId = ShoppingCartId,
                    Game = _context.Games.SingleOrDefault(
                        p => p.Id == id),
                    DateCreated = System.DateTime.Now
                };

                _context.CartItems.Add(cartItem);
            }
            
            _context.SaveChanges();
        }

        public string GetCartId()
        {
            if (_httpContextAccessor.HttpContext.Session.GetString("CartSessionKey") == null)
            {
                if (!string.IsNullOrWhiteSpace(_httpContextAccessor.HttpContext.User.Identity.Name))
                {
                    _httpContextAccessor.HttpContext.Session.SetString(CartSessionKey,
                        _httpContextAccessor.HttpContext.User.Identity.Name);
                }
                else
                {
                    // Generate a new random GUID using System.Guid class.     
                    Guid tempCartId = Guid.NewGuid();
                    _httpContextAccessor.HttpContext.Session.SetString(CartSessionKey, tempCartId.ToString());
                }
                
            }

            return _httpContextAccessor.HttpContext.Session.GetString(CartSessionKey);
        }
        
        public List<CartItem> GetCartItems()
        {
            ShoppingCartId = GetCartId();

            return _context.CartItems.Include(c => c.Game).Where(
                c => c.CartId == ShoppingCartId).ToList();
        }

        public void RemoveAllItem()
        {
            ShoppingCartId = GetCartId();
            _context.CartItems.RemoveRange(_context.CartItems.Where(g => g.CartId == ShoppingCartId));
            _context.SaveChanges();
        }

        public void RemoveItem(int id)
        {
            ShoppingCartId = GetCartId();
            var game = _context.CartItems.FirstOrDefault(g => g.GameId == id);
            if (game != null)
            {
                _context.CartItems.Remove(game);
            }
            else
            {
                throw new NotFoundException($"Can't delete game with id = {id} from cart");
            }

            _context.SaveChanges();
        }
    }
}
