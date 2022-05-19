using CandyStore.Models;

namespace CandyStore.ViewModels;

public class ShoppingCartViewModel
{
    public ShoppingCart ShoppingCart { get; set; } = default!;
    public decimal ShoppingCartTotal { get; set; }
}