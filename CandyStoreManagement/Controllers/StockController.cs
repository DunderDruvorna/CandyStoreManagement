using CandyStore.Data.Models;
using CandyStore.Data.Services.Interfaces;
using CandyStore.Data.Services.Wrapper;
using CandyStoreManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CandyStoreManagement.Controllers;

public class StockController : Controller
{
    readonly ICandyRepository _candyRepository;
    readonly ICategoryRepository _categoryRepository;

    public StockController(IRepositoryWrapper repository)
    {
        _candyRepository = repository.Candy;
        _categoryRepository = repository.Categories;
    }

    public IActionResult Index()
    {
        var model = new StockViewModel
        {
            CandyList = _candyRepository.GetAllCandy().ToList(),
            Categories = _categoryRepository.GetCategories().ToList(),
        };
        return View(model);
    }

    public IActionResult Create(Candy candy)
    {
        _candyRepository.AddCandy(candy);

        return RedirectToAction("Index");
    }
}