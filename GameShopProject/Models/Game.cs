using System.ComponentModel.DataAnnotations;

namespace GameShop.Models;

public class Game
{   
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }
    
}