using GameShop.Models;

namespace GameShopProject.Services.Interfaces;

public interface IOrderService
{
    public void MakeOrder();
    public IList<Order> GetOrderByName(string email);
}