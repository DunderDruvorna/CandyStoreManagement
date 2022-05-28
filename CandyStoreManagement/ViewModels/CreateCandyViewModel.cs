using CandyStore.Data.Models;

namespace CandyStoreManagement.ViewModels;

public class CreateCandyViewModel
{
    public CreateCandyViewModel(Candy candy, IEnumerable<Category> categories)
    {
        Candy = candy;
        Categories = categories;
    }

    public Candy Candy { get; set; }
    public IEnumerable<Category> Categories { get; set; }
}