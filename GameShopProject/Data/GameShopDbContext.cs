using GameShop.Models;
using GameShopProject.Models;
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
    
    public DbSet<Role> Roles { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        string adminRoleName = "admin";
        string userRoleName = "user";

        string adminEmail = "admin@mail.ru";
        string adminPassword = "123";
 
        // добавляем роли
        Role adminRole = new Role { Id = 1, Name = adminRoleName };
        Role userRole = new Role { Id = 2, Name = userRoleName };
        User adminUser = new User { Id = 1, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };
 
        modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole});
        modelBuilder.Entity<User>().HasData(new User[] { adminUser });
        base.OnModelCreating(modelBuilder);
    }

}