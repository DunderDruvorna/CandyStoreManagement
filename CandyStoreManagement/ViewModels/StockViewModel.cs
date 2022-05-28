using CandyStore.Data.Models;

namespace CandyStoreManagement.ViewModels;

public class StockViewModel
{
    public StockViewModel(IEnumerable<Candy> candyList, IEnumerable<Category> categories)
    {
        CandyList = candyList;
        Categories = categories;
    }

    public IEnumerable<Candy> CandyList { get; set; }
    public IEnumerable<Category> Categories { get; set; }
}