using GameShop.Models;

namespace GameShopProject.Services.Interfaces;

public interface ICartService
{
    public void AddToCard(int id);
    public string GetCartId();
    public List<CartItem> GetCartItems();
    public void RemoveAllItem();
    public void RemoveItem(int id);
    
}