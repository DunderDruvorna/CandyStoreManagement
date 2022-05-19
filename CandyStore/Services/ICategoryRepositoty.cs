using CandyStore.Models;

namespace CandyStore.Services;

public interface ICategoryRepository
{
    IEnumerable<Category> GetCategories();

    Category? GetCategory(int id);
    Category? GetCategoryByName(string? name);
}