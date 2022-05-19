using CandyStore.Models;

namespace CandyStore.Services;

public class RepositoryWrapper : IRepositoryWrapper
{
    readonly DataContext _context;
    ICandyRepository? _candy;
    ICategoryRepository? _categories;
    IOrderRepository? _orders;

    public RepositoryWrapper(DataContext context)
    {
        _context = context;
    }

    public ICandyRepository Candy => _candy ??= new CandyRepository(_context);
    public ICategoryRepository Categories => _categories ??= new CategoryRepository(_context);
    public IOrderRepository Orders => _orders ??= new OrderRepository(_context);
}