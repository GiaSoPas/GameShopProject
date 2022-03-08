using GameShop.Models;

namespace GameShopProject.ViewModels;

public class OrderGameUserModel
{
    public List<Order> Orders { get; set; }
    public List<Game> Games { get; set; }
    public Task<User> User { get; set; }
}