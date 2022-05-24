using CandyStore.Data.Models;
using CandyStore.Data.Services.Interfaces;
using CandyStore.Data.Services.Wrapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CandyStore.Controllers;

[Authorize]
public class OrderController : Controller
{
    readonly IOrderRepository _orderRepository;
    readonly ShoppingCart _shoppingCart;

    public OrderController(IRepositoryWrapper repository, ShoppingCart shoppingCart)
    {
        _orderRepository = repository.Orders;
        _shoppingCart = shoppingCart;
    }

    public IActionResult Checkout()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Checkout(Order order)
    {
        _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();
        if (_shoppingCart.ShoppingCartItems.Count == 0) ModelState.AddModelError("", "Your cart is empty");

        if (!ModelState.IsValid) return View(order);

        _orderRepository.CreateOrder(order);
        _shoppingCart.ClearCart();
        return RedirectToAction("CheckoutComplete");
    }

    public IActionResult CheckoutComplete()
    {
        ViewBag.CheckoutCompleteMessage = "Thank you for your order. Enjoy your candy!";
        return View();
    }
}