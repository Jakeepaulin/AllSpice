namespace AllSpice.Services;

public class IngredientsService
{
  private readonly IngredientsRepository _repo;

  public IngredientsService(IngredientsRepository repo)
  {
    _repo = repo;
  }

  internal Ingredient CreateIngredient(Ingredient newIngredient)
  {
    return _repo.CreateIngredient(newIngredient);
  }

  internal Ingredient DeleteIngredient(int ingredientId, Account userInfo)
  {
    return _repo.DeleteIngredient(ingredientId);
  }

  internal List<Ingredient> GetIngredientsByRecipe(int recipeId)
  {
    return _repo.GetIngredientsByRecipe(recipeId);
  }
}