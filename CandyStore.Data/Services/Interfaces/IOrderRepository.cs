using CandyStore.Data.Models;

namespace CandyStore.Data.Services.Interfaces;

public interface IOrderRepository
{
    void CreateOrder(Order order);

    public IEnumerable<Order> GetAllOrders();
}