using GameShop.Models;

namespace GameShopProject.Services.Interfaces;

public interface IGameService
{
    public Game GetGameById(int id);
    public IList<Game> GetAllGames();

    public void CreateGame(string name, string description, decimal price);

    public void DeleteGame(int id);

    public void UpdateGame(int id, string name, string description, decimal price);
}