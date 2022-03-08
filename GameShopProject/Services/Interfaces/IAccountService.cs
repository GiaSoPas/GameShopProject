using GameShop.Models;

namespace GameShopProject.Services.Interfaces;

public interface IAccountService
{
    public Task<User> GetUserByEmailPassword(string email, string password);
    public Task<User> GetUserByEmail(string email);

    public Task AddUser(string email, string password, string name, string surname, DateTime dateOfBirthday);
}