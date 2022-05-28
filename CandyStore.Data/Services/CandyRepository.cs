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
        return _context.Candy.Include(c => c.Category).Include(c => c.Sales);
    }

    public IEnumerable<Candy> GetCandyOnSale()
    {
        return _context.Candy.Where(c => c.Sales.Any());
    }

    public Candy? GetCandy(int id)
    {
        return _context.Candy.FirstOrDefault(c => c.CandyID == id);
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

    public Candy UpdateCandy(Candy updatedCandy)
    {
        var OldCandy = _context.Candy.FirstOrDefault(c => c.CandyID == updatedCandy.CandyID);
        if (OldCandy != null)
        {
            OldCandy = updatedCandy;
            _context.SaveChanges();
            return updatedCandy;
        }

        return updatedCandy;
    }
}