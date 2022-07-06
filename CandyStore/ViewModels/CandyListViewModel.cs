using CandyStore.Data.Models;

namespace CandyStore.ViewModels;

public class CandyListViewModel
{
    public IEnumerable<Candy> Candy { get; set; } = default!;
    public Candy? SaleCandy { get; set; }
    public string? Category { get; set; }
    public Candy? Stock { get; set; }
}