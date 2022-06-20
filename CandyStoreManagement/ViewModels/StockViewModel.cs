using CandyStore.Data.Models;

namespace CandyStoreManagement.ViewModels;

public class StockViewModel
{
    public StockViewModel() { }

    public StockViewModel(IList<Candy> candyList, IList<Category> categories)
    {
        CandyList = candyList;
        Categories = categories;
    }

    public IList<Candy> CandyList { get; set; } = default!;
    public IList<Category> Categories { get; set; } = default!;
}