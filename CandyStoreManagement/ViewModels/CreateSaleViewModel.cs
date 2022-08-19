using CandyStore.Data.Models;

namespace CandyStoreManagement.ViewModels;

public class CreateSaleViewModel
{
    public CreateSaleViewModel() { }

    public CreateSaleViewModel(IEnumerable<Candy> candy)
    {
        AllCandy = candy;
    }

    public Sale Sale { get; set; } = new();
    public IEnumerable<Candy> AllCandy { get; set; } = default!;
    public IEnumerable<int> SelectedCandy { get; set; } = default!;
}