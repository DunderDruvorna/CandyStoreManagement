using CandyStore.Services;
using CandyStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CandyStoreManagement.Controllers
{
    public class SaleController : Controller
    {
        private readonly ICandyRepository _candyRepository;

        public SaleController(ICandyRepository candyRepository)
        {
            _candyRepository = candyRepository; 
        }
        

        public IActionResult Create()
        {
            var candyListViewModel = new CandyListViewModel();
            candyListViewModel.Candy = _candyRepository.GetAllCandy();
            return View(candyListViewModel);
        }
        public IActionResult CreateSale()
        {
            return View();
        }
    }
}
