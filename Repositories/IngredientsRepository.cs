using System.Collections.Generic;
using System.Data;
using csharp_allspice.Models;
using Dapper;

namespace csharp_allspice.Repositories
{
  public class IngredientsRepository
  {
    private readonly IDbConnection _db;

    public IngredientsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Ingredient> GetByRecipeId(int id)
    {
      string sql = @"
      SELECT 
      r.*,
      prod.*
      FROM ingredients r 
      JOIN recipes prod ON r.recipeId = prod.id
      WHERE recipeId = @id;";


      return _db.Query<Ingredient, Recipe, Ingredient>(sql, (ingredient, recipe) =>
      {
        ingredient.Recipe = recipe;
        return ingredient;
      }, new { id }, splitOn: "id");
    }
  }
}