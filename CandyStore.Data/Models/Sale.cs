using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandyStore.Data.Models;

public class Sale
{
    [Key]
    public int SaleID { get; set; }

    [Range(1, 100)]
    public int Discount { get; set; } = 1;

    [NotMapped]
    public decimal PriceMultiplier => 1 - (decimal)Discount / 100;

    public ICollection<Candy> Candy { get; set; } = new List<Candy>();

    public DateTime StartDate { get; set; } = DateTime.Today;
    public DateTime EndDate { get; set; } = DateTime.Today.AddDays(7);

    [NotMapped]
    public bool IsActive => DateTime.UtcNow > StartDate.ToUniversalTime() && DateTime.UtcNow < EndDate.ToUniversalTime();
}