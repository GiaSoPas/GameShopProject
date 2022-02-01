using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace GameShop.Models;

public class User
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public DateTime DateOfBirthday { get; set; }

    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    public string Password { get; set; }
}