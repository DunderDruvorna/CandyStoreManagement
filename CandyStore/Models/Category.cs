namespace CandyStore.Models;

public class Category
{
    public int CategoryID { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public ICollection<Candy> Candy { get; set; } = default!;
}