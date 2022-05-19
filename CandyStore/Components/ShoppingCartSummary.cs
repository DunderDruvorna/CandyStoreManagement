using CandyStore.Models;
using CandyStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CandyStore.Components;

public class ShoppingCartSummary : ViewComponent
{
    readonly ShoppingCart _shoppingCart;

    public ShoppingCartSummary(ShoppingCart shoppingCart)
    {
        _shoppingCart = shoppingCart;
    }

    public IViewComponentResult Invoke()
    {
        _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();
        return View(new ShoppingCartViewModel
        {
            ShoppingCart = _shoppingCart,
            ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
        });
    }
}