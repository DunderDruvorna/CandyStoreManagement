using CandyStore.Data.Models;
using CandyStore.Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CandyStore.Data.Services;

public class CategoryRepository : ICategoryRepository
{
    readonly DataContext _context;

    public CategoryRepository(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<Category> GetCategories()
    {
        return _context.Categories.Include(c => c.Candy);
    }

    public Category? GetCategory(int id)
    {
        return _context.Categories.Include(c => c.Candy).FirstOrDefault(c => c.CategoryID == id);
    }

    public Category? GetCategoryByName(string? name)
    {
        return _context.Categories.Include(c => c.Candy).FirstOrDefault(c => c.Name.Equals(name));
    }
}