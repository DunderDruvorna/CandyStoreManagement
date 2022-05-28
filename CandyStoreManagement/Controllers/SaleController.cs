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

    public IActionResult Create()
    {
        return View(new CreateSaleViewModel(_candyRepository.GetAllCandy()));
    }

    public IActionResult CreateSale(CreateSaleViewModel sale)
    {
        _salesRepository.CreateSale(new Sale
        {
            Discount = sale.Discount,
            Candy = _candyRepository.GetAllCandy().Where(c => sale.SelectedCandy.Contains(c.CandyID)).ToList(),
            StartDate = sale.StartDate,
            EndDate = sale.EndDate,
        });

        return RedirectToAction("Index", "AdminHome");
    }
}