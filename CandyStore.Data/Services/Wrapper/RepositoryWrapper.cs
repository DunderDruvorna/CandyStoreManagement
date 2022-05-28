using CandyStore.Data.Services.Interfaces;

namespace CandyStore.Data.Services.Wrapper;

public class RepositoryWrapper : IRepositoryWrapper
{
    readonly DataContext _context;
    ICandyRepository? _candy;
    ICategoryRepository? _categories;
    IOrderRepository? _orders;
    ISaleRepository? _sales;
    ITemplateRepository? _template;

    public RepositoryWrapper(DataContext context)
    {
        _context = context;
    }

    public ICandyRepository Candy => _candy ??= new CandyRepository(_context);
    public ICategoryRepository Categories => _categories ??= new CategoryRepository(_context);
    public IOrderRepository Orders => _orders ??= new OrderRepository(_context);
    public ISaleRepository Sales => _sales ??= new SaleRepository(_context);
    public ITemplateRepository Template => _template ??= new TemplateRepository(_context);
}