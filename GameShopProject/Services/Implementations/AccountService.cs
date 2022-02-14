using GameShop.Models;
using GameShopProject.Data;
using Microsoft.EntityFrameworkCore;

namespace GameShopProject.Services.Implementations;

public class AccountService
{
    private readonly GameShopDbContext _context;

    public AccountService(GameShopDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetUserByEmailPassword(string email, string password)
    {
        User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        
        return user;
    }

    public async Task<User> GetUserByEmail(string email)
    {
        User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        return user;
    }

    public async Task AddUser(string email, string password, string name, string surname, DateTime dateOfBirthday)
    {
        _context.Users.Add(new User { Email = email, Password = password, Name = name, Surname = surname, DateOfBirthday = dateOfBirthday.ToUniversalTime()});
        await _context.SaveChangesAsync();
    }
    
}