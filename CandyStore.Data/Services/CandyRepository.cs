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
        CheckIfCandyStillOnSale();
        return _context.Candy.Include(c => c.Category);
    }

    public IEnumerable<Candy> GetCandyOnSale()
    {
        CheckIfCandyStillOnSale();
        return _context.Candy.Include(c => c.Category).Where(p => p.IsOnSale);
    }

    public Candy? GetCandy(int id)
    {
        CheckIfCandyStillOnSale();
        return _context.Candy.FirstOrDefault(c => c.CandyID == id);
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

    public void CheckIfCandyStillOnSale()
    {
        var candyNotOnSaleAnymore = _context.Candy.Where(c => c.SaleEnd.Date < DateTime.UtcNow.Date);
        if (candyNotOnSaleAnymore != null)
        {
            foreach (var candy in candyNotOnSaleAnymore)
            {
                candy.IsOnSale = false;
                candy.SaleStart = default;
                candy.SaleEnd = default;
                candy.SalePrice = 0;
            }

            _context.SaveChanges();
        }

        var candyStartSale = _context.Candy.Where(c => c.SaleStart.Date == DateTime.UtcNow.Date);
        if (candyStartSale != null)
        {
            foreach (var candy in candyStartSale) candy.IsOnSale = true;
            _context.SaveChanges();
        }
    }
}