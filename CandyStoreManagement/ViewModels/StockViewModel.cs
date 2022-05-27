using CandyStore.Data.Models;

namespace CandyStoreManagement.ViewModels;

public class StockViewModel
{
    public IEnumerable<Candy> CandyList { get; set; }
    public IEnumerable<Category> Categories { get; set; }
}