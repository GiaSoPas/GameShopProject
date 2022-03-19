using System.ComponentModel.DataAnnotations;

namespace GameShopProject.ViewModels;

public class CreateUpdateGameModel
{
    public int Id {get; set;}
    
    [Required(ErrorMessage = "Не указано имя")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Не указано описание")]
    public string Description { get; set; }
    
    [Required(ErrorMessage = "Не указана цена")]
    public decimal Price { get; set; }
}