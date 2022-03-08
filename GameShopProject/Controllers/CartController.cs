using GameShopProject.Services;
using GameShopProject.Services.Implementations;
using GameShopProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameShopProject.Controllers;

public class CartController : Controller
{
    private readonly ICartService _cartService;

    private readonly AccountService _accountService;

    public CartController(CartService cartService, AccountService accountService)
    {
        _cartService = cartService;
        _accountService = accountService;
    }

    public IActionResult Cart()
    {
        return View(_cartService.GetCartItems());
    }

    public IActionResult AddToCart(int id, string url)
    {
        _cartService.AddToCard(id);
        return Redirect(url);
    }

    public IActionResult RemoveAllItemFromCart(string url)
    {
        _cartService.RemoveAllItem();
        return Redirect(url);
    }

    public IActionResult RemoveItemFromCart(int id, string url)
    {
        _cartService.RemoveItem(id);
        return Redirect(url);
    }
}