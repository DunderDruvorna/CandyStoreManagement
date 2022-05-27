using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandyStore.Data.Models;

public class Sale
{
    public int SaleID { get; set; }

    [Range(0, 1)]
    public decimal Discount { get; set; } // 0 = No sale, 1 = Free

    public ICollection<Candy> Candy { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    [NotMapped]
    public bool IsActive => DateTime.UtcNow > StartDate.ToUniversalTime() && DateTime.UtcNow < EndDate.ToUniversalTime();
}