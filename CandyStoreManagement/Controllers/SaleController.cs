using CandyStore.Data.Models;
using CandyStore.Data.Services.Interfaces;
using CandyStore.Data.Services.Wrapper;
using CandyStoreManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CandyStoreManagement.Controllers;

public class SaleController : Controller
{
    readonly ICandyRepository _candyRepository;
    readonly ICategoryRepository _categoriesRepository;
    readonly ISaleRepository _salesRepository;

    public SaleController(IRepositoryWrapper repository)
    {
        _candyRepository = repository.Candy;
        _salesRepository = repository.Sales;
        _categoriesRepository = repository.Categories;
    }

    public IActionResult Index()
    {
        ViewBag.Categories = _categoriesRepository.GetCategories();
        return View(_salesRepository.GetSales());
    }

    public IActionResult Create()
    {
        ViewBag.AllCandy = _candyRepository.GetAllCandy();

        return View(new Sale());
    }

    [HttpPost]
    public IActionResult Create(Sale model)
    {
        _salesRepository.CreateSale(model);

        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var sale = _salesRepository.GetSale(id);

        if (sale is null) return BadRequest();

        return View(new EditSaleViewModel(sale, _categoriesRepository.GetCategories(), _candyRepository.GetAllCandy()));
    }

    [HttpPost]
    public IActionResult Edit(EditSaleViewModel model)
    {
        return RedirectToAction("Index");
    }

    public IActionResult Remove(int id)
    {
        _candyRepository.RemoveCandy(id);

        return RedirectToAction("Index");
    }
}