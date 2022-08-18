using CandyStore.Data.Models;

namespace CandyStore.Data.Services.Interfaces;

public interface ISaleRepository
{
    IEnumerable<Sale> GetSales();
    Sale? GetSale(int id);
    IEnumerable<Candy> GetCandyOnSale();
    IEnumerable<Candy> GetCandyOnSale(int saleID);
    Sale CreateSale(Sale sale);
    Sale? UpdateSale(Sale sale);
}