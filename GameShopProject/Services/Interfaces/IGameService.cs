using GameShop.Models;

namespace GameShopProject.Services.Interfaces;

public interface IGameService
{
    public Game GetGameById(int id);
    public IList<Game> GetAllGames();
}