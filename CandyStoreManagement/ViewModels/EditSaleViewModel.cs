using CandyStore.Data.Models;

namespace CandyStoreManagement.ViewModels;

public class EditSaleViewModel
{
    public EditSaleViewModel() { }

    public EditSaleViewModel(Sale sale, IEnumerable<Candy> candy)
    {
        Sale = sale;
        AllCandy = candy;
    }

    public Sale Sale { get; set; } = new();
    public IEnumerable<Candy> AllCandy { get; set; } = default!;

    public IEnumerable<int> SelectedCandy { get; set; } = default!;
}