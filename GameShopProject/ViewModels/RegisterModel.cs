using System.ComponentModel.DataAnnotations;

namespace GameShopProject.ViewModels;

public class RegisterModel
{   
    [Required(ErrorMessage = "Не указан Email")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Не указан пароль")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Пароль введен неверно")]
    public string ConfirmPassword { get; set; }
    
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Не указана дата рождения")]
    public DateTime DateOfBirthday { get; set; }
}