using CandyStore.Data.Models;

namespace CandyStoreManagement.ViewModels;

public class StockViewModel
{
    public IEnumerable<Sale> AllSales { get; set; } = default!;
    public IEnumerable<Candy> AllCandy { get; set; } = default!;
    public IEnumerable<Category> AllCategories { get; set; } = default!;
}