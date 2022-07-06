using CandyStore.Data;
using CandyStore.Data.Models;
using CandyStore.Data.Services.Interfaces;
using CandyStore.Data.Services.Wrapper;
using CandyStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CandyStoreManagement.Controllers
{
    public class StockController : Controller
    {
        //private readonly DataContext _dataContext;

        //public StockController(DataContext dataContext)
        //{
        //    _dataContext = dataContext;
        //}
        //public IActionResult Index()
        //{
        //    IEnumerable<Candy> candyList = _dataContext.Candy;
        //    return View(candyList);
        //}
        ////Get
        //public IActionResult Adding(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var candy = _dataContext.Candy.Find(id);
        //    if (candy == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(candy);
        //}
        ////Post
        //[HttpPost]
        ////Candy candy
        //public IActionResult Adding(Candy candy)
        //{

        //    //if (ModelState.IsValid)
        //    //{
        //    //    var item = candy.StockCount + 1;
        //    //    _dataContext.Candy.Update(item);
        //    //    _dataContext.SaveChanges();
        //    //    return RedirectToAction("Index");
        //    //}
        //    //return View(candy);


        //}

        private readonly ICandyRepository _candyRepository;

        public StockController(IRepositoryWrapper candyRepository)
        {
            _candyRepository = candyRepository.Candy;
        }
        public IActionResult Index()
        {
            IEnumerable<Candy> candyList = _candyRepository.GetAllCandy();
            return View(candyList);
        }
        //Get
        public IActionResult AddToStock(int id)
        {
            var candyListViewModel = new CandyListViewModel();
            candyListViewModel.Stock = _candyRepository.GetCandy(id);
            if (candyListViewModel.Stock == null)
            {
                return NotFound();
            }
            return View(candyListViewModel);
        }

        public IActionResult AddToStockResult(CandyListViewModel candyList)
        {
            var candy = _candyRepository.GetCandy(candyList.Stock.CandyID);
            candy.StockCount = candyList.Stock.StockCount + candy.StockCount;
                
            _candyRepository.UpdateCandy(candy);
             
            return RedirectToAction("Index");

        }


    }
}
