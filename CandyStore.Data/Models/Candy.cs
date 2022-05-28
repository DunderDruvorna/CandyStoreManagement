namespace CandyStore.Data.Models;

public class Candy
{
    public int CandyID { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? ImageURL { get; set; }
    public string? ImageThumbnailURL { get; set; }
    public int? CategoryID { get; set; }
    public Category? Category { get; set; }
    public ICollection<Sale> Sales { get; set; } = default!;
    public int Stock { get; set; }
}