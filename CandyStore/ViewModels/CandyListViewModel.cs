using CandyStore.Models;

namespace CandyStore.ViewModels;

public class CandyListViewModel
{
    public IEnumerable<Candy> Candy { get; set; } = default!;
    public string? Category { get; set; }
}