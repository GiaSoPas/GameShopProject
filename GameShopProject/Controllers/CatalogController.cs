using GameShopProject.Services;
using GameShopProject.Services.Implementations;
using GameShopProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameShopProject.Controllers;

public class CatalogController: Controller
{
    private readonly IGameService _service;
    
    public CatalogController(GameService service)
    {
        _service = service;
    }

    [Route("Catalog")]
    public IActionResult Catalog()
    {
        return View(_service.GetAllGames());
    }
    
    [Route("Catalog/{id:int}")]
    public IActionResult Item(int id)
    {
        return View(_service.GetGameById(id));
    }
}