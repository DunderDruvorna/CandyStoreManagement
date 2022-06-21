using CandyStore.Data.Models;

namespace CandyStoreManagement.ViewModels;

public class EditSaleViewModel
{
    public EditSaleViewModel() { }

    public EditSaleViewModel(Sale sale, IEnumerable<Category> categories, IEnumerable<Candy> candy)
    {
        Sale = sale;
        Categories = categories;
        Candy = candy;
    }

    public Sale Sale { get; set; } = new();
    public IEnumerable<Candy> Candy { get; set; } = default!;
    public IEnumerable<Category> Categories { get; set; } = default!;

    public IEnumerable<int> SelectedCandy { get; set; } = default!;
}