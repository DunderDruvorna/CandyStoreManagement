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
        return _context.Candy.Where(c => c.Sales.Any()).ToList();
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

        if (sale is null) return sale;

        _context.Sales.Remove(sale);
        _context.SaveChanges();

        return sale;
    }

    public Sale? SetSaleDiscount(int saleID, decimal discount)
    {
        var sale = _context.Sales.FirstOrDefault(s => s.SaleID == saleID);

        if (sale is null)
            return sale;

        sale.Discount = discount;
        _context.SaveChanges();

        return sale;
    }

    public Sale? SetSaleStart(int saleID, DateTime date)
    {
        var sale = _context.Sales.FirstOrDefault(s => s.SaleID == saleID);

        if (sale is null)
            return sale;

        sale.StartDate = date;
        _context.SaveChanges();

        return sale;
    }

    public Sale? SetSaleEnd(int saleID, DateTime date)
    {
        var sale = _context.Sales.FirstOrDefault(s => s.SaleID == saleID);

        if (sale is null)
            return sale;

        sale.EndDate = date;
        _context.SaveChanges();

        return sale;
    }

    public bool AddCandyToSale(int saleID, int candyID)
    {
        var sale = _context.Sales.Include(s => s.Candy).FirstOrDefault(s => s.SaleID == saleID);
        var candy = _context.Candy.FirstOrDefault(c => c.CandyID == candyID);

        if (sale is null || candy is null)
            return false;

        sale.Candy.Add(candy);
        _context.SaveChanges();

        return true;
    }

    public bool RemoveCandyFromSale(int saleID, int candyID)
    {
        var sale = _context.Sales.Include(s => s.Candy).FirstOrDefault(s => s.SaleID == saleID);
        var candy = _context.Candy.FirstOrDefault(c => c.CandyID == candyID);

        if (sale is null || candy is null || !sale.Candy.Contains(candy))
            return false;

        sale.Candy.Remove(candy);
        _context.SaveChanges();

        return true;
    }
}