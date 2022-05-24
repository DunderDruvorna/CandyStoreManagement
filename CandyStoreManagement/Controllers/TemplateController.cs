using CandyStore.Data.Services.Interfaces;
using CandyStore.Data.Services.Wrapper;
using Microsoft.AspNetCore.Mvc;

namespace CandyStoreManagement.Controllers;

public class TemplateController : Controller
{
    readonly ITemplateRepository _template;

    public TemplateController(IRepositoryWrapper repository)
    {
        _template = repository.Template;
    }

    public IActionResult Index()
    {
        var result = _template.Get();

        return View(result);
    }
}