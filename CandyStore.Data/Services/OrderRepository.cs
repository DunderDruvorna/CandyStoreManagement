using CandyStore.Data.Models;
using CandyStore.Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CandyStore.Data.Services;

public class OrderRepository : IOrderRepository
{
    readonly DataContext _context;
    readonly ShoppingCart _shoppingCart;

    public OrderRepository(DataContext context)
    {
        _context = context;
        _shoppingCart = new ShoppingCart(context);
    }

    public IEnumerable<Order> GetAllOrders()
    {
        return _context.Orders.Include(o => o.OrderDetails);
    }

    public void CreateOrder(Order order)
    {
        order.OrderPlaced = DateTime.Now;
        order.OrderTotal = _shoppingCart.GetShoppingCartTotal();
        _context.Orders.Add(order);
        _context.SaveChanges();

        var shoppingCartItems = _shoppingCart.GetShoppingCartItems();

        _context.OrderDetails.AddRange(shoppingCartItems.Select(shoppingCartItem => new OrderDetail
        {
            OrderID = order.OrderID,
            CandyID = shoppingCartItem.Candy.CandyID,
            Amount = shoppingCartItem.Amount,
            Price = shoppingCartItem.Candy.Price,
        }));

        _context.SaveChanges();
    }
    
}