using GameShop.Models;
using GameShopProject.Data;
using GameShopProject.Models;
using GameShopProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameShopProject.Services.Implementations;

public class AccountService : IAccountService
{
    private readonly GameShopDbContext _context;

    public AccountService(GameShopDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetUserByEmailPassword(string email, string password)
    {
        User user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        
        return user;
    }

    public async Task<User> GetUserByEmail(string email)
    {
        User user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == email);

        return user;
    }

    public async Task AddUser(string email, string password, string name, string surname, DateTime dateOfBirthday)
    {
        User user = new User { Email = email, Password = password, Name = name, Surname = surname, DateOfBirthday = dateOfBirthday.ToUniversalTime()};
        
        Role userRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "user");
        if (userRole != null)
            user.Role = userRole;
        
        _context.Users.Add(user);

        await _context.SaveChangesAsync();
    }
    
}