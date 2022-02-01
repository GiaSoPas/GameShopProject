using System.ComponentModel.DataAnnotations;
using GameShopProject.Data;

namespace GameShop.Models;

public class Order
{
    [Key] 
    public int Id { get; set; }

    public int UserId { get; set; }

    public User User { get; set; }

    public List<Game> Games { get; set; }
    
    public DateTime OrderTime { get; set; }


}