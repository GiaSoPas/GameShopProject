using System.ComponentModel.DataAnnotations;
using GameShopProject.Data;

namespace GameShop.Models;

public class Order
{
    [Key]
    public int Id { get; set; }

    public int OrderId { get; set; }
        
    public string Username { get; set; }

    public int GameId { get; set; }
    
    public DateTime Date { get; set; }
    
}