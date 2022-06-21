using CandyStore.Data.Models;

namespace CandyStoreManagement.ViewModels;

public class EditCandyViewModel
{
    public EditCandyViewModel() { }

    public EditCandyViewModel(Candy candy, IEnumerable<Category> categories, IEnumerable<Sale> sales)
    {
        Candy = candy;
        Categories = categories;
        Sales = sales;
    }

    public Candy Candy { get; set; } = new();
    public IEnumerable<Category> Categories { get; set; } = default!;
    public IEnumerable<Sale> Sales { get; set; } = default!;

    public IEnumerable<int> SelectedSales { get; set; } = default!;
}