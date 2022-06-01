using CandyStore.Data.Models;
using CandyStore.Data.Services.Interfaces;
using CandyStore.Data.Services.Wrapper;
using CandyStoreManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CandyStoreManagement.Controllers;

public class SaleController : Controller
{
    readonly ICandyRepository _candyRepository;
    readonly ISaleRepository _salesRepository;

    public SaleController(IRepositoryWrapper repository)
    {
        _candyRepository = repository.Candy;
        _salesRepository = repository.Sales;
    }

    public IActionResult Index()
    {
        return View(_salesRepository.GetSales());
    }

    public IActionResult Create()
    {
        ViewBag.AllCandy = _candyRepository.GetAllCandy();
        return View(new CreateSaleViewModel());
    }

    public IActionResult CreateSale(CreateSaleViewModel sale)
    {
        _salesRepository.CreateSale(new Sale
        {
            Discount = sale.Discount,
            Candy = sale.SelectedCandy.Select(c => _candyRepository.GetCandy(c) ?? new Candy()).ToList(),
            StartDate = sale.StartDate,
            EndDate = sale.EndDate,
        });

        return RedirectToAction("Index", "Sale");
    }

    public IActionResult Remove(int id)
    {
        _salesRepository.RemoveSale(id);
        return RedirectToAction("Index", "Sale");
    }
}