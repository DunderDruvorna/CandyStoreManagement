using CandyStore.Services;
using CandyStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CandyStore.Controllers;

public class HomeController : Controller
{
    readonly ICandyRepository _candyRepo;

    public HomeController(IRepositoryWrapper repository)
    {
        _candyRepo = repository.Candy;
    }

    public IActionResult Index()
    {
        return View(new HomeViewModel
        {
            CandyOnSale = _candyRepo.GetCandyOnSale(),
        });
    }
}