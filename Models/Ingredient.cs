namespace csharp_allspice.Models
{
  public class Ingredient
  {
    public Ingredient(int id, string title, string description, int recipeId, Recipe recipe)
    {
      this.Id = id;
      this.Title = title;
      this.Description = description;
      this.RecipeId = recipeId;
      this.Recipe = recipe;

    }
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; }
  }
}