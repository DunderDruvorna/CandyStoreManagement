using CandyStore.Models;
using CandyStoreManagementAPI.Services.Interfaces;

namespace CandyStoreManagementAPI.Services.Wrapper;

public class RepositoryWrapper : IRepositoryWrapper
{
    readonly DataContext _context;
    ITemplateRepository? _templateData;

    public RepositoryWrapper(DataContext context)
    {
        _context = context;
    }

    public ITemplateRepository TemplateData => _templateData ??= new TemplateRepository(_context);
}