using CandyStore.Models;

namespace CandyStore.Services;

public interface ICandyRepository
{
    IEnumerable<Candy> GetAllCandy();
    IEnumerable<Candy> GetCandyOnSale();
    Candy? GetCandy(int id);
    Candy UpdateCandy(Candy updatedCandy);
}