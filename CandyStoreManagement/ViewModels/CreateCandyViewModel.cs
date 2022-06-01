using CandyStore.Data.Models;

namespace CandyStoreManagement.ViewModels;

public class CreateCandyViewModel
{
    public CreateCandyViewModel(IEnumerable<Category> categories)
    {
        Categories = categories;
    }

    public Candy Candy { get; set; } = new();
    public IEnumerable<Category> Categories { get; set; }
}