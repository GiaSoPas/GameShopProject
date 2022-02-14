using GameShop.Models;
using GameShopProject.Data;
using GameShopProject.Exceptions;

namespace GameShopProject.Services.Implementations;

public class GameService
{
    private readonly GameShopDbContext _context;

    public GameService(GameShopDbContext context)
    {
        _context = context;
    }

    public Game GetGameById(int id)
    { 
        var game = _context.Games.FirstOrDefault(g => g.Id == id);

        if (game == null)
        {
            throw new NotFoundException($"Game with id = {id} not found");
        }

        return game;
    }

    public IList<Game> GetAllGames()
    {
        var game = _context.Games.ToList();

        return game;
    }
}