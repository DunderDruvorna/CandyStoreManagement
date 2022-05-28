using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandyStore.Data.Models;

public class Sale
{
    [Key]
    public int SaleID { get; set; }

    [Range(0, 1)]
    public decimal Discount { get; set; } // 0 = No sale, 1 = Free

    public ICollection<Candy> Candy { get; set; } = default!;
    public DateTime StartDate { get; set; } = DateTime.Today;
    public DateTime EndDate { get; set; } = DateTime.Today.AddDays(7);

    [NotMapped]
    public bool IsActive => DateTime.UtcNow > StartDate.ToUniversalTime() && DateTime.UtcNow < EndDate.ToUniversalTime();
}