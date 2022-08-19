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
    readonly ISaleRepository _saleRepository;

    public StockController(IRepositoryWrapper repository)
    {
        _candyRepository = repository.Candy;
        _categoryRepository = repository.Categories;
        _saleRepository = repository.Sales;
    }

    public IActionResult Index()
    {
        var candy = _candyRepository.GetAllCandy();

        ViewBag.Categories = _categoryRepository.GetCategories();
        ViewBag.Sales = _saleRepository.GetSales();

        return View(candy);
    }

    public IActionResult Create()
    {
        ViewBag.Categories = _categoryRepository.GetCategories();
        ViewBag.Sales = _saleRepository.GetSales();

        return View(new Candy());
    }

    [HttpPost]
    public IActionResult Create(Candy candy)
    {
        try
        {
            _candyRepository.AddCandy(candy);
        }
        catch
        {
            return RedirectToAction("Index");
        }

        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var candy = _candyRepository.GetCandy(id);
        var categories = _categoryRepository.GetCategories();
        var sales = _saleRepository.GetSales();
        if (candy is null) return BadRequest();

        return View(new EditCandyViewModel(candy, categories, sales));
    }

    [HttpPost]
    public IActionResult Edit(EditCandyViewModel model)
    {
        _candyRepository.UpdateCandy(model.Candy);

        return RedirectToAction("Index");
    }

    public IActionResult Remove(int id)
    {
        _candyRepository.RemoveCandy(id);

        return RedirectToAction("Index");
    }
}