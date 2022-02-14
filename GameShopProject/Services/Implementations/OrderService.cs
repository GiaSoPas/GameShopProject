using System.Runtime.InteropServices.ComTypes;
using GameShop.Models;
using GameShopProject.Data;
using GameShopProject.Services.Interfaces;

namespace GameShopProject.Services.Implementations;

public class OrderService : IOrderService
{
    private readonly GameShopDbContext _context;

    private readonly CartService _cartService;

    public OrderService(GameShopDbContext context, CartService cartService)
    {
        _context = context;
        _cartService = cartService;
    }
    

    public void MakeOrder()
    {
        List<CartItem> cartItems = _cartService.GetCartItems();
        var email = _cartService.GetCartId();
        // search number of last order
        var temp = _context.Orders.OrderBy(c => c.OrderId).LastOrDefault(c => c.Username == email);
        int lastOrder;
        if (temp == null)
        {
            lastOrder = 1;
        }
        else
        {
            lastOrder = temp.OrderId + 1;
        }
        
        // putting data about order in db
        foreach (var items in cartItems)
        {
            _context.Orders.Add(new Order()
            {
                OrderId = lastOrder,
                Username = email,
                GameId = items.GameId,
                Date = DateTime.Now
            });
        }
        _cartService.RemoveAllItem();
        _context.SaveChanges();
    }
    
    
}