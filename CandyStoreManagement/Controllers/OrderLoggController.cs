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

        public IActionResult Orders(OrderLoggViewModel model)
        {
            var orderLoggViewModel = new OrderLoggViewModel();
            if (model.currency != null)
			{
                orderLoggViewModel.Orders = _orderRepository.GetAllOrders();
                var json = _orderRepository.currencyChangeAsync(model.currency);
                var result = json.Result;

                decimal currencyExchangevalue = decimal.Parse(result);
                orderLoggViewModel.currencyExchangeRate = currencyExchangevalue;
                orderLoggViewModel.currency = model.currency;
            }

            orderLoggViewModel.Orders = _orderRepository.GetAllOrders();
            return View(orderLoggViewModel);
        }
        public IActionResult OrderDetails(int id, string currency)
        {
            var orderLoggViewModel = new OrderLoggViewModel();
            if(currency != null)
			{
                var json = _orderRepository.currencyChangeAsync(currency);
                var result = json.Result;

                decimal currencyExchangevalue = decimal.Parse(result);
                orderLoggViewModel.currencyExchangeRate = currencyExchangevalue;
                orderLoggViewModel.currency = currency;
            }
            orderLoggViewModel.Order = _orderRepository.GetOrderById(id);
            orderLoggViewModel.OrderDetails = _orderRepository.GetOrderDetails(id);
            return View(orderLoggViewModel);
        }
    }
}
