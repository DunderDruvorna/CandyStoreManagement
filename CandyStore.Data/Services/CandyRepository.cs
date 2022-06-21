using CandyStore.Data.Models;
using CandyStore.Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CandyStore.Data.Services;

public class CandyRepository : ICandyRepository
{
    readonly DataContext _context;

    public CandyRepository(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<Candy> GetAllCandy()
    {
        return _context.Candy.Include(c => c.Category).Include(c => c.Sales).ToList();
    }

    public IEnumerable<Candy> GetCandyOnSale()
    {
        return _context.Sales.SelectMany(s => s.Candy).Include(c => c.Category).ToList();
    }

    public Candy? GetCandy(int id)
    {
        return _context.Candy.Include(c => c.Category).Include(c => c.Sales).FirstOrDefault(c => c.CandyID == id);
    }

    public Candy UpdateCandy(Candy updatedCandy)
    {
        var OldCandy = _context.Candy.FirstOrDefault(c => c.CandyID == updatedCandy.CandyID);
        if (OldCandy != null)
        {
            OldCandy.Name = updatedCandy.Name;
            OldCandy.Description = updatedCandy.Description;
            OldCandy.CategoryID = updatedCandy.CategoryID;
            OldCandy.Price = updatedCandy.Price;
            OldCandy.Sales = updatedCandy.Sales;
            OldCandy.Stock = updatedCandy.Stock;

            _context.SaveChanges();
            return OldCandy;
        }

        return OldCandy;
    }

    public Candy AddCandy(Candy candy)
    {
        var newCandy = _context.Candy.Add(new Candy
        {
            Name = candy.Name,
            CategoryID = candy.CategoryID,
            Description = candy.Description,
            Price = candy.Price,
        });
        _context.SaveChanges();

        return newCandy.Entity;
    }

    public Candy? RemoveCandy(int id)
    {
        var candy = _context.Candy.FirstOrDefault(c => c.CandyID == id);
        if (candy is null)
            return null;

        _context.Candy.Remove(candy);
        _context.SaveChanges();

        return candy;
    }
}