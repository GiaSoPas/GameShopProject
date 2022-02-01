using GameShop.Models;
using GameShopProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GameShopProject.Services;

public class CartService
{
    private readonly GameShopDbContext _context;

    public CartService(GameShopDbContext context)
    {
        _context = context;
    }

    public List<Game> GetGamesInCart(int userId)
    {
        var games = _context.CartItems.FirstOrDefault(g => g.UserId == userId)?.Games ?? new List<Game>();

        return games;
    }

    public void AddGameInCard(int gameId, int userId)
    {
        GetGamesInCart(userId).Add(_context.Games.FirstOrDefault(g => g.Id == gameId));

        _context.SaveChanges();
    }

    public void DeleteGameFromCart(int gameId, int userId)
    {
        GetGamesInCart(userId).Remove(_context.Games.FirstOrDefault(g => g.Id == gameId));

        _context.SaveChanges();
    }

    public void ClearCart(int userId)
    {
        GetGamesInCart(userId).Clear();
        _context.SaveChanges();
    }
}