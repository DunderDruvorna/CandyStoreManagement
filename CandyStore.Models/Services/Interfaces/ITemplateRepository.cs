using CandyStore.Data.Models;

namespace CandyStore.Data.Services.Interfaces;

// DO NOT REMOVE -> DUPLICATE!

public interface ITemplateRepository
{
    IEnumerable<Candy> Get();
}