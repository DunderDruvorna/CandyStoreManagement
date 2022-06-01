using CandyStore.Data.Models;

namespace CandyStoreManagement.ViewModels;

public class CreateSaleViewModel : Sale
{
    public IList<int> SelectedCandy { get; set; } = default!;
}