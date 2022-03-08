using GameShop.Models;
using GameShopProject.Data;
using GameShopProject.Exceptions;
using GameShopProject.Services.Interfaces;

namespace GameShopProject.Services.Implementations;

public class GameService: IGameService
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