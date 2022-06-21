using CandyStore.Data.Models;

namespace CandyStore.Data.Services.Interfaces;

public interface ISaleRepository
{
    IEnumerable<Sale> GetSales();
    Sale? GetSale(int id);
    IEnumerable<Candy> GetCandyOnSale();
    IEnumerable<Candy> GetCandyOnSale(int saleID);
    Sale CreateSale(Sale sale);
    Sale? RemoveSale(int saleID);
    Sale? SetSaleDiscount(int saleID, decimal discount);
    Sale? SetSaleStart(int saleID, DateTime date);
    Sale? SetSaleEnd(int saleID, DateTime date);
    bool AddCandyToSale(int saleID, int candyID);
    bool RemoveCandyFromSale(int saleID, int candyID);
}