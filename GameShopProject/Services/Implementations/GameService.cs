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

    public void CreateGame(string name, string description, decimal price)
    {
        Game game = new Game()
            {Id = _context.Games.OrderBy(x=>x.Id).LastOrDefault().Id + 1, Name = name, Description = description, Price = price};
        _context.Games.Add(game);

        _context.SaveChanges();
    }

    public void DeleteGame(int id)
    {
        Game game = _context.Games.FirstOrDefault(g => g.Id == id);

        if (game != null)
        {
            _context.Games.Remove(game);
        }
        else
        {
            throw new NotFoundException($"Can't delete game with id = {id}");
        }
        
        _context.SaveChanges();
    }

    public void UpdateGame(int id, string name, string description, decimal price)
    {
        Game game = _context.Games.FirstOrDefault(g => g.Id == id);

        game.Description = description;
        game.Name = name;
        game.Price = price;

        _context.SaveChanges();

    }
}