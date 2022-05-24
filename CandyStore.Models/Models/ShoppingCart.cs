using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CandyStore.Data.Models;

public class ShoppingCart
{
    readonly DataContext _context;

    public ShoppingCart(DataContext context)
    {
        _context = context;
    }

    public string ShoppingCartID { get; set; } = default!;
    public List<ShoppingCartItem>? ShoppingCartItems { get; set; }

    public static ShoppingCart GetCart(IServiceProvider services)
    {
        var session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session ?? throw new NullReferenceException();

        var context = services.GetService<DataContext>() ?? throw new NullReferenceException();
        var cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
        session.SetString("CartId", cartId);

        return new ShoppingCart(context) { ShoppingCartID = cartId, };
    }

    public void AddToCart(Candy candy, int amount)
    {
        var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(s => s.CandyID == candy.CandyID && s.ShoppingCartID.Equals(ShoppingCartID));

        if (shoppingCartItem is null)
        {
            _context.ShoppingCartItems.Add(new ShoppingCartItem
            {
                ShoppingCartID = ShoppingCartID,
                Candy = candy,
                Amount = amount,
            });
            _context.SaveChanges();
            return;
        }

        shoppingCartItem.Amount++;
        _context.SaveChanges();
    }

    public int RemoveFromCart(Candy candy)
    {
        var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(s => s.CandyID == candy.CandyID && s.ShoppingCartID.Equals(ShoppingCartID));

        var localAmount = 0;

        if (shoppingCartItem is null)
            return localAmount;

        if (shoppingCartItem.Amount > 1)
            localAmount = shoppingCartItem.Amount--;
        else
            _context.ShoppingCartItems.Remove(shoppingCartItem);

        _context.SaveChanges();

        return localAmount;
    }

    public List<ShoppingCartItem> GetShoppingCartItems()
    {
        return ShoppingCartItems ??= _context.ShoppingCartItems.Where(c => c.ShoppingCartID.Equals(ShoppingCartID)).Include(s => s.Candy).ToList();
    }

    public void ClearCart()
    {
        var cartItems = _context.ShoppingCartItems.Where(c => c.ShoppingCartID.Equals(ShoppingCartID));

        _context.ShoppingCartItems.RemoveRange(cartItems);
        _context.SaveChanges();
    }

    public decimal GetShoppingCartTotal()
    {
        return _context.ShoppingCartItems.Where(c => c.ShoppingCartID == ShoppingCartID).Select(c => c.Candy.Price * c.Amount).Sum() ?? 0;
    }
}