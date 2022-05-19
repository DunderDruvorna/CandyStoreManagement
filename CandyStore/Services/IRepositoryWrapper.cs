namespace CandyStore.Services;

public interface IRepositoryWrapper
{
    ICandyRepository Candy { get; }
    ICategoryRepository Categories { get; }
    IOrderRepository Orders { get; }
}