using System.Net.NetworkInformation;
using System.Security.Claims;
using GameShop.Models;
using GameShopProject.Services;
using GameShopProject.Services.Implementations;
using GameShopProject.Services.Interfaces;
using GameShopProject.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace GameShopProject.Controllers;

public class AccountController: Controller
{
    private readonly IAccountService _accountService;
    private readonly IOrderService _orderService;
    private readonly IGameService _gameService;

    public AccountController(AccountService accountService, OrderService orderService, GameService gameService)
    {
        _accountService = accountService;
        _orderService = orderService;
        _gameService = gameService;
    }
    
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _accountService.GetUserByEmailPassword(model.Email, model.Password);
            if (user != null)
            {
                await Authenticate(user); // аутентификация
                if (user.RoleId == 1)
                {
                    return RedirectToAction("Index", "Admin");
                }
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Некорректные логин и(или) пароль");
        }
        return View(model);
    }
    private async Task Authenticate(User user)
    {
        // создаем один claim
        var claims = new List<Claim>
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
            new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
        };
        // создаем объект ClaimsIdentity
        ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        // установка аутентификационных куки
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
    }
    
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _accountService.GetUserByEmail(model.Email);
            if (user == null)
            {
                // добавляем пользователя в бд
                await _accountService.AddUser(model.Email,model.Password, model.Name, model.Surname, model.DateOfBirthday);
                var regUser = await _accountService.GetUserByEmailPassword(model.Email, model.Password);
                await Authenticate(regUser); // аутентификация
 
                return RedirectToAction("Index", "Home");
            }
            else
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
        }
        return View(model);
    }
    
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Account()
    {
        OrderGameUserModel vm = new OrderGameUserModel();
        vm.Orders = _orderService.GetOrderByName(User.Identity.Name).ToList();
        vm.Games = _gameService.GetAllGames().ToList();
        vm.User = _accountService.GetUserByEmail(User.Identity.Name);
        //ViewData["Orders"] = _orderService.GetOrderByName(User.Identity.Name);
        // ViewData["User"] = _accountService.GetUserByEmail(User.Identity.Name);
        //var user = _accountService.GetUserByEmail(User.Identity.Name);
        
        if (vm.User==null)
        {
            return RedirectToAction("Index", "Home");
        }
        return View(vm);
    }
}