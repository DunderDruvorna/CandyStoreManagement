using CandyStore.Data.Models;
using CandyStore.Data.Services.Interfaces;
using CandyStore.Data.Services.Wrapper;
using CandyStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CandyStore.Controllers;

public class ShoppingCartController : Controller
{
    readonly ICandyRepository _candyRepository;
    readonly ShoppingCart _shoppingCart;

    public ShoppingCartController(IRepositoryWrapper repository, ShoppingCart shoppingCart)
    {
        _candyRepository = repository.Candy;
        _shoppingCart = shoppingCart;
    }

    public ViewResult Index()
    {
        _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();

        var shoppingCartViewModel = new ShoppingCartViewModel
        {
            ShoppingCart = _shoppingCart,
            ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
        };

        return View(shoppingCartViewModel);
    }

    public RedirectToActionResult AddToShoppingCart(int candyID)
    {
        var selectedCandy = _candyRepository.GetCandy(candyID);

        if (selectedCandy is not null) _shoppingCart.AddToCart(selectedCandy, 1);

        return RedirectToAction("Index", "Home");
    }

    public RedirectToActionResult RemoveFromShoppingCart(int candyID)
    {
        var selectedCandy = _candyRepository.GetCandy(candyID);

        if (selectedCandy is not null) _shoppingCart.RemoveFromCart(selectedCandy);

        return RedirectToAction("Index");
    }

    public RedirectToActionResult ClearCart()
    {
        _shoppingCart.ClearCart();

        return RedirectToAction("Index");
    }
}