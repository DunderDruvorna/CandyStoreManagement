using System.ComponentModel.DataAnnotations.Schema;

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
    public int Stock { get; set; }
    public ICollection<Sale>? Sales { get; set; } = default!;

    [NotMapped]
    public decimal ActivePrice
    {
        get
        {
            if (Sales is not null && ActiveSale is not null) return Price * ActiveSale.PriceMultiplier;

            return Price;
        }
    }

    [NotMapped]
    public Sale? ActiveSale => Sales?.Any(s => s.IsActive) ?? false ? Sales.Where(s => s.IsActive).MaxBy(s => s.Discount) : null;
}