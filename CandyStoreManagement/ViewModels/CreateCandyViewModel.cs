using CandyStore.Data.Models;

namespace CandyStoreManagement.ViewModels;

public class CreateCandyViewModel
{
    public Candy Candy { get; set; }
    public IEnumerable<Category> Categories { get; set; }
}