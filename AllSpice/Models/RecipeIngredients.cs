using AllSpice.Interfaces;

namespace AllSpice.Models;

public class RecipeIngredients : IRepoItem<int>
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string AccountId { get; set; }
  public int RecipeId { get; set; }
}