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
        public IActionResult CreateSale(CandyListViewModel newCandySalePrice)
        {
            var candyToGoOnSale = _candyRepository.GetCandy(newCandySalePrice.SaleCandy.CandyID);
            if(candyToGoOnSale != null)
            {
                candyToGoOnSale.SaleStart = newCandySalePrice.SaleCandy.SaleStart;
                candyToGoOnSale.SalePrice = newCandySalePrice.SaleCandy.SalePrice;
                candyToGoOnSale.SaleEnd = newCandySalePrice.SaleCandy.SaleEnd;
                _candyRepository.UpdateCandy(candyToGoOnSale);
            }
            return RedirectToAction("Index","AdminHome"); 

        }
    }
}
