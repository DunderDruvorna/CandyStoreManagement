using System.Diagnostics;
using CandyStore.Services;
using CandyStore.ViewModels;
using CandyStoreManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace CandyStoreManagement.Controllers
{
    public class AdminHomeController : Controller
    {
        private readonly ILogger<AdminHomeController> _logger;
        private readonly ICandyRepository _candyRepository;

        public AdminHomeController(ILogger<AdminHomeController> logger, ICandyRepository candyRepository)
        {
            _logger = logger;
            _candyRepository = candyRepository; 
        }

        public IActionResult Index()
        {
            var candyListViewModel = new CandyListViewModel();
            candyListViewModel.Candy = _candyRepository.GetAllCandy().Where(c => c.IsOnSale == true);
            return View(candyListViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new CandyStore.ViewModels.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}