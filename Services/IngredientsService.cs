using System.Collections.Generic;
using csharp_allspice.Models;
using csharp_allspice.Repositories;

namespace csharp_allspice.Services
{
  public class IngredientsService
  {
    private readonly IngredientsRepository _repo;

    public IngredientsService(IngredientsRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Ingredient> GetByRecipeId(int id)
    {
      IEnumerable<Ingredient> data = _repo.GetByRecipeId(id);
      return data;
    }

  }
}