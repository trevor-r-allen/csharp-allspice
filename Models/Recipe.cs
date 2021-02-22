namespace csharp_allspice.Models
{
  public class Recipe
  {
    public Recipe(int id, string title, string description)
    {
      this.Id = id;
      this.Title = title;
      this.Description = description;

    }
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
  }
}