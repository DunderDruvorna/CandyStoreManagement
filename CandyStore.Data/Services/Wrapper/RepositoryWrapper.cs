using CandyStore.Data.Services.Interfaces;
using CandyStore.Services;
using CandyStore.Data.Models;

namespace CandyStore.Data.Services.Wrapper;

public class RepositoryWrapper : IRepositoryWrapper
{
    readonly DataContext _context;
    readonly ShoppingCart _shoppingCart;
    ICandyRepository? _candy;
    ICategoryRepository? _categories;
    IOrderRepository? _orders;
    ITemplateRepository? _template;

    public RepositoryWrapper(DataContext context, ShoppingCart shoppingCart)
    {
        _context = context;
        _shoppingCart = shoppingCart;   
    }

    public ICandyRepository Candy => _candy ??= new CandyRepository(_context);
    public ICategoryRepository Categories => _categories ??= new CategoryRepository(_context);
    public IOrderRepository Orders => _orders ??= new OrderRepository(_context, _shoppingCart);
    public ITemplateRepository Template => _template ??= new TemplateRepository(_context);
}