using CandyStore.Data.Services.Interfaces;
using CandyStore.Data.Services.Wrapper;
using CandyStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CandyStore.Controllers;

public class CandyController : Controller
{
    readonly ICandyRepository _candyRepo;
    readonly ICategoryRepository _categoriesRepo;

    public CandyController(IRepositoryWrapper repository)
    {
        _candyRepo = repository.Candy;
        _categoriesRepo = repository.Categories;
    }

    public ViewResult List(string? category = null)
    {
        var currentCategory = _categoriesRepo.GetCategoryByName(category);

        return currentCategory is null
                   ? View(new CandyListViewModel
                   {
                       Candy = _candyRepo.GetAllCandy().OrderBy(c => c.CandyID),
                       Category = "All Candy",
                   })
                   : View(new CandyListViewModel
                   {
                       Candy = _candyRepo.GetAllCandy().Where(c => c.CategoryID == currentCategory.CategoryID),
                       Category = currentCategory.Name,
                   });
    }

    public IActionResult Details(int candyID)
    {
        var candy = _candyRepo.GetCandy(candyID);
        if (candy is null) return NotFound();


        return View(candy);
    }
}