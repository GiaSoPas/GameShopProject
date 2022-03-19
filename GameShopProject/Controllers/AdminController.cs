using GameShop.Models;
using GameShopProject.Services.Implementations;
using GameShopProject.Services.Interfaces;
using GameShopProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameShopProject.Controllers;

public class AdminController : Controller
{
    private readonly IGameService _service;
    
    public AdminController(GameService service)
    {
        _service = service;
    }
    
    [Authorize(Roles = "admin")]
    public IActionResult Index()
    {
        return View(_service.GetAllGames());
    }

    [HttpGet]
    public IActionResult CreateGame()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult CreateGame(CreateUpdateGameModel model)
    {
        _service.CreateGame(model.Name, model.Description, model.Price);
        return RedirectToAction("Index", "Admin");
    }

    public IActionResult DeleteGame(int id, string url)
    {
        _service.DeleteGame(id);
        return Redirect(url);
    }
    
    [HttpGet]
    //[Route("UpdateGame/{id:int}")]
    public IActionResult UpdateGame(int id)
    {
        CreateUpdateGameModel model = new CreateUpdateGameModel();
        Game game = _service.GetGameById(id);
        model.Name = game.Name;
        model.Description = game.Description;
        model.Price = game.Price;
        model.Id = game.Id;
        return View(model);
    }
    [HttpPost]
    public IActionResult UpdateGame(CreateUpdateGameModel model)
    {   
        _service.UpdateGame(model.Id, model.Name, model.Description, model.Price);
        return RedirectToAction("Index", "Admin");
    }
}