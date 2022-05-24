using CandyStore.Data.Services.Interfaces;

namespace CandyStore.Data.Services.Wrapper;

public interface IRepositoryWrapper
{
    ICandyRepository Candy { get; }
    ICategoryRepository Categories { get; }
    IOrderRepository Orders { get; }
    ITemplateRepository Template { get; }
}