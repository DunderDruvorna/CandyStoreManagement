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
        return View(new CreateSaleViewModel(_candyRepository.GetAllCandy()));
    }

    public IActionResult CreateSale(CreateSaleViewModel createSaleModel)
    {
        _salesRepository.CreateSale(new Sale
        {
            Discount = createSaleModel.Sale.Discount,
            Candy = createSaleModel.SelectedCandy.Select(c => _candyRepository.GetCandy(c) ?? new Candy()).ToList(),
            StartDate = createSaleModel.Sale.StartDate,
            EndDate = createSaleModel.Sale.EndDate,
        });

        return RedirectToAction("Index");
    }
}