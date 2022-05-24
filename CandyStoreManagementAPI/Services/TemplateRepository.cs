using CandyStore.Data;
using CandyStore.Data.Models;
using CandyStoreManagementAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CandyStoreManagementAPI.Services;

public class TemplateRepository : ITemplateRepository
{
    readonly DataContext _context;

    public TemplateRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Candy>> Get()
    {
        return await _context.Candy.ToListAsync();
    }
}