using CandyStoreManagementAPI.Services.Interfaces;

namespace CandyStoreManagementAPI.Services.Wrapper;

public interface IRepositoryWrapper
{
    public ITemplateRepository TemplateData { get; }
}