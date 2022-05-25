using CandyStore.Data.Models;
using CandyStore.Data.Services.Interfaces;

namespace CandyStore.Data.Services;

// DO NOT REMOVE -> DUPLICATE!

public class TemplateRepository : ITemplateRepository
{
    readonly DataContext _context;

    public TemplateRepository(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<Candy> Get()
    {
        return _context.Candy;
    }
}