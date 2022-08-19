using CandyStore.Data.Models;

namespace CandyStoreManagement.ViewModels;

public class OrderLoggViewModel
{
    public IEnumerable<Order>? Orders { get; set; }
    public Order Order { get; set; }
    public IEnumerable<OrderDetail> OrderDetails { get; set; }
    public string currency { get; set; }
    public decimal? currencyExchangeRate { get; set; }
}