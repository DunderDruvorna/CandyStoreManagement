using CandyStore.Data.Services.Interfaces;
using CandyStore.Data.Services.Wrapper;
using Microsoft.AspNetCore.Mvc;

namespace CandyStore.Components;

public class CategoryMenu : ViewComponent
{
    readonly ICategoryRepository _repoCategories;

    public CategoryMenu(IRepositoryWrapper repository)
    {
        _repoCategories = repository.Categories;
    }

    public IViewComponentResult Invoke()
    {
        return View(_repoCategories.GetCategories().OrderBy(c => c.Name));
    }
}