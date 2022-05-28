using CandyStore.Data.Models;

namespace CandyStoreManagement.ViewModels;

public class CreateSaleViewModel : Sale
{
    public CreateSaleViewModel() { }

    public CreateSaleViewModel(IEnumerable<Candy> candyList)
    {
        AllCandy = candyList;
    }

    public IEnumerable<Candy> AllCandy { get; set; } = default!;
    public IEnumerable<int> SelectedCandy { get; set; } = default!;
    public int DiscountPercentage { get; set; }
    public new decimal Discount => (decimal)DiscountPercentage / 100;
}