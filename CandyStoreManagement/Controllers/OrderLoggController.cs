using CandyStore.Data.Services.Interfaces;
using CandyStore.Data.Services.Wrapper;
using CandyStoreManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CandyStoreManagement.Controllers
{
    public class OrderLoggController : Controller
    {

        readonly IOrderRepository _orderRepository;

        public OrderLoggController(IRepositoryWrapper repository)
        {
            _orderRepository = repository.Orders;
        }

        public IActionResult Orders()
        {
            var orderLoggViewModel = new OrderLoggViewModel();
            orderLoggViewModel.Orders = _orderRepository.GetAllOrders();
            return View(orderLoggViewModel);
        }
    }
}
