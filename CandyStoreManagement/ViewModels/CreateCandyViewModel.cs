using CandyStore.Data.Models;

namespace CandyStoreManagement.ViewModels;

public class CreateCandyViewModel
{
    public Candy Candy { get; set; } = new();

    public IEnumerable<Category> Categories { get; set; } = default!;
    public IEnumerable<Sale> Sales { get; set; } = default!;

    public IEnumerable<int> SelectedSales { get; set; } = default!;
}