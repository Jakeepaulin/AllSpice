using AllSpice.Interfaces;

namespace AllSpice.Models;

public class Favorite : IRepoItem<int>
{
  public int favoriteId { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public int RecipeId { get; set; }
  public string AccountId { get; set; }
  public int Id { get; set; }
}