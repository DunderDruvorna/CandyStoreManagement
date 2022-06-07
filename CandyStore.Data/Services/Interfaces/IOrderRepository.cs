using CandyStore.Data.Models;

namespace CandyStore.Data.Services.Interfaces;

public interface IOrderRepository
{
    void CreateOrder(Order order);

    public IEnumerable<Order> GetAllOrders();

    public Task<string> currencyChangeAsync(string newCurrency);
    public Order GetOrderById(int id);
    public IEnumerable<OrderDetail> GetOrderDetails(int id);

}