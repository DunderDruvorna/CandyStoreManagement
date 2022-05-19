namespace CandyStore.Models;

public class OrderDetail
{
    public int OrderDetailID { get; set; }
    public int CandyID { get; set; }
    public Candy? Candy { get; set; }
    public int Amount { get; set; }
    public decimal? Price { get; set; }
    public int OrderID { get; set; }
    public Order? Order { get; set; }
}