using CandyStore.Data.Models;
using CandyStore.Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CandyStore.Data.Services;

public class SaleRepository : ISaleRepository
{
    readonly DataContext _context;

    public SaleRepository(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<Candy> GetCandyOnSale()
    {
        return _context.Sales.SelectMany(s => s.Candy).Include(c => c.Category).ToList();
    }

    public IEnumerable<Candy> GetCandyOnSale(int saleID)
    {
        return _context.Sales.Include(s => s.Candy).FirstOrDefault(s => s.SaleID == saleID)?.Candy.ToList() ?? new List<Candy>();
    }

    public Sale CreateSale(Sale sale)
    {
        var newSale = _context.Sales.Add(new Sale
                              {
                                  Discount = sale.Discount,
                                  Candy = sale.Candy,
                                  StartDate = sale.StartDate,
                                  EndDate = sale.EndDate,
                              })
                              .Entity;
        _context.SaveChanges();

        return newSale;
    }

    public Sale? RemoveSale(int saleID)
    {
        var sale = _context.Sales.FirstOrDefault(s => s.SaleID == saleID);

        if (sale is null)
            return sale;

        _context.Sales.Remove(sale);
        _context.SaveChanges();

        return sale;
    }

    public IEnumerable<Sale> GetSales()
    {
        return _context.Sales.Include(s => s.Candy).ToList();
    }

    public Sale? GetSale(int id)
    {
        return _context.Sales.Include(s => s.Candy).FirstOrDefault(s => s.SaleID == id);
    }

    public Sale? UpdateSale(Sale updatedSale)
    {
        var sale = _context.Sales.FirstOrDefault(s => s.SaleID == updatedSale.SaleID);

        if (sale is null) return sale;

        sale.Discount = updatedSale.Discount;
        sale.Candy = updatedSale.Candy;
        sale.StartDate = updatedSale.StartDate;
        sale.EndDate = updatedSale.EndDate;

        _context.SaveChanges();
        return sale;
    }
}