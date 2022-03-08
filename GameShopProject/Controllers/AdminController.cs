using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameShopProject.Controllers;

public class AdminController : Controller
{
    [Authorize(Roles = "admin")]
    public IActionResult Index()
    {
        return View();
    }
}