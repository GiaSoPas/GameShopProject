using GameShop.Models;
using Microsoft.EntityFrameworkCore;

namespace GameShopProject.Data;

public class GameShopDbContext : DbContext
{
    public GameShopDbContext(DbContextOptions<GameShopDbContext> options) : base(options)
    {
    }

    public DbSet<Game> Games { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<CartItem> CartItems { get; set; }
    
}