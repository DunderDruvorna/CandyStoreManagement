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
    public IList<PropertyChange<string>> NameChanges { get; set; } = default!;
}

public class PropertyChange<T>
{
    public PropertyChange(int id, T? oldValue, T? newValue)
    {
        EntityID = id;
        OldValue = oldValue;
        NewValue = newValue;
    }

    public int EntityID { get; set; }
    public T? OldValue { get; set; }
    public T? NewValue { get; set; }
}