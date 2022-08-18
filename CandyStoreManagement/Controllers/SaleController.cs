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
        ViewBag.AllCandy = _candyRepository.GetAllCandy();
        ViewBag.Categories = _categoriesRepository.GetCategories();
        return View(_salesRepository.GetSales());
    }

    [HttpPost]
    public IActionResult Create(CreateSaleViewModel model)
    {
        var sale = model.Sale;
        var allCandy = _candyRepository.GetAllCandy();

        foreach (var candyID in model.SelectedCandy)
        {
            var candy = allCandy.FirstOrDefault(c => c.CandyID == candyID);

            if (candy is null) continue;

            sale.Candy.Add(candy);
        }

        _salesRepository.CreateSale(sale);

        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var sale = _salesRepository.GetSale(id);

        if (sale is null) return BadRequest();

        return View(new EditSaleViewModel(sale, _candyRepository.GetAllCandy()));
    }

    [HttpPost]
    public IActionResult Edit(EditSaleViewModel model)
    {
        var sale = model.Sale;
        var allCandy = _candyRepository.GetAllCandy();

        foreach (var candyID in model.SelectedCandy)
        {
            var candy = allCandy.FirstOrDefault(c => c.CandyID == candyID);

            if (candy is null) continue;

            sale.Candy.Add(candy);
        }

        _salesRepository.UpdateSale(sale);

        return RedirectToAction("Index");
    }

    public IActionResult Remove(int id)
    {
        _candyRepository.RemoveCandy(id);

        return RedirectToAction("Index");
    }
}