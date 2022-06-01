using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandyStore.Data.Models;

public class Candy
{
    [Key]
    public int CandyID { get; set; }

    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? ImageURL { get; set; }
    public string? ImageThumbnailURL { get; set; }
    public int? CategoryID { get; set; }
    public Category? Category { get; set; }
    public int Stock { get; set; }
    public IList<Sale>? Sales { get; set; }

    [NotMapped]
    public decimal ActivePrice
    {
        get
        {
            if (Sales is not null && Sales.Any(s => s.IsActive)) return Price * Sales.Where(s => s.IsActive).Min(s => s.PriceMultiplier);

            return Price;
        }
    }

    [NotMapped]
    public Sale? ActiveSale => Sales?.Any(s => s.IsActive) ?? false ? Sales.Where(s => s.IsActive).MaxBy(s => s.Discount) : null;
}