using CandyStore.Models;

namespace CandyStore.Services;

public interface IOrderRepository
{
    void CreateOrder(Order order);
}