using CandyStore.Models;
using Microsoft.EntityFrameworkCore;

namespace CandyStore.Services;

public class CandyRepository : ICandyRepository
{
    readonly DataContext _context;

    public CandyRepository(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<Candy> GetAllCandy()
    {
        return _context.Candy.Include(c => c.Category);
    }

    public IEnumerable<Candy> GetCandyOnSale()
    {
        return _context.Candy.Include(c => c.Category).Where(p => p.IsOnSale);
    }

    public Candy? GetCandy(int id)
    {
        return _context.Candy.FirstOrDefault(c => c.CandyID == id);
    }
}