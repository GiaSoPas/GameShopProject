using System.ComponentModel.DataAnnotations;

namespace GameShop.Models;

public class CartItem
{
    [Key]
    public string ItemId { get; set; }

    public string CartId { get; set; }
    
    public System.DateTime DateCreated { get; set; }
    
    public int GameId { get; set; }

    public virtual Game Game { get; set; }
    
}