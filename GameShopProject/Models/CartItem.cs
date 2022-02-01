using System.ComponentModel.DataAnnotations;

namespace GameShop.Models;

public class CartItem
{
    [Key]
    public int UserId { get; set; }

    public User User { get; set; }

    public List<Game> Games { get; set; } = new List<Game>();

}