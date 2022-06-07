using CandyStore.Data.Models;
using CandyStore.Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CandyStore.Data.Services;

public class OrderRepository : IOrderRepository
{
    readonly DataContext _context;
    readonly ShoppingCart _shoppingCart;

    private readonly string apikey = "S5b154FjetTiKjcj1czRYy5Uk3Nz5vcGXFAAMkAC";

    public OrderRepository(DataContext context, ShoppingCart shoppingCart)
    {
        _context = context;
        _shoppingCart = shoppingCart;
    }

    public IEnumerable<Order> GetAllOrders()
    {
        return _context.Orders;
    }
    public Order GetOrderById(int id)
    {

        return _context.Orders.FirstOrDefault(o => o.OrderID == id);

    }
    public IEnumerable<OrderDetail> GetOrderDetails(int id)
    {
        return _context.OrderDetails.Include(od => od.Candy).Where(o => o.OrderID == id);
    }

    public void CreateOrder(Order order)
    {
        order.OrderPlaced = DateTime.Now;
        order.OrderTotal = _shoppingCart.GetShoppingCartTotal();
        _context.Orders.Add(order);
        _context.SaveChanges();

        var shoppingCartItems = _shoppingCart.GetShoppingCartItems();

        foreach (var shoppingCartItem in shoppingCartItems)
        {
            var orderDetail = new OrderDetail
            {
                Amount = shoppingCartItem.Amount,
                Price = shoppingCartItem.Candy.Price,
                CandyID = shoppingCartItem.Candy.CandyID,
                OrderID = order.OrderID
            };

            _context.OrderDetails.Add(orderDetail);
            _context.SaveChanges();
        }
        ;
    }
    [HttpGet]
    public async Task<string> currencyChangeAsync(string newCurrency)
    {
        string result;
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://api.currencyapi.com/v3/latest?apikey={apikey}&currencies={newCurrency}&base_currency=SEK"),
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var streambody = await response.Content.ReadAsStreamAsync();

            using (var stream = new StreamReader(streambody))
            {
                string json = stream.ReadToEnd();
                result = JObject.Parse(json)["data"][newCurrency]["value"].ToString();
            }
        }
        return result;

    }
}