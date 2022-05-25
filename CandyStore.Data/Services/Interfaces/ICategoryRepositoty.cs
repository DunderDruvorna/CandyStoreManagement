using CandyStore.Data.Models;

namespace CandyStore.Data.Services.Interfaces;

public interface ICategoryRepository
{
    IEnumerable<Category> GetCategories();

    Category? GetCategory(int id);
    Category? GetCategoryByName(string? name);
}