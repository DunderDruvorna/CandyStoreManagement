using Microsoft.AspNetCore.Mvc;

namespace CandyStore.Controllers;

public class ContactController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}