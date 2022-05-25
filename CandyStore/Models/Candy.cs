using System.ComponentModel.DataAnnotations.Schema;

namespace CandyStore.Models;

public partial class Candy
{
    public int CandyID { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public string? ImageURL { get; set; }
    public string? ImageThumbnailURL { get; set; }
    public bool IsInStock { get; set; }
    public int CategoryID { get; set; }
    public Category? Category { get; set; }

    
}
public partial class Candy
{
    //Sale 
    public DateTime SaleStart { get; set; }
    public DateTime SaleEnd { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal? SalePrice { get; set; }
    public bool IsOnSale { get; set; }
}