using GameShopProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameShopProject.Controllers;

public class CartController: Controller
{
    private readonly CartService _cartService;

    private readonly AccountService _accountService;

    public CartController(CartService cartService, AccountService accountService)
    {
        _cartService = cartService;
        _accountService = accountService;
    }
    
    public async Task<IActionResult> Cart(string email)
    {
        var user = await _accountService.GetUserByEmail(email);
        var games = _cartService.GetGamesInCart(user.Id);
        return View(games);
    }

    public async Task<IActionResult> AddToCart(int gameId, string email)
    {
        var user = await _accountService.GetUserByEmail(email);
        _cartService.AddGameInCard(gameId, user.Id);

        return RedirectToAction("Catalog", "Catalog");
    }
    
}