using CandyStore.Data.Models;

namespace CandyStore.Data.Services.Interfaces;

public interface ICandyRepository
{
    IEnumerable<Candy> GetAllCandy();
    IEnumerable<Candy> GetCandyOnSale();
    Candy? GetCandy(int id);
}