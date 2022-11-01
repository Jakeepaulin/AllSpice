namespace AllSpice.Services;

public class RecipesService
{
  private readonly RecipesRepository _repo;

  public RecipesService(RecipesRepository repo)
  {
    _repo = repo;
  }

  internal Recipe CreateRecipe(Recipe newRecipe)
  {
    return _repo.CreateRecipe(newRecipe);
  }

  internal List<Recipe> GetAllRecipes()
  {
    return _repo.GetAllRecipes();
  }

  internal Recipe GetRecipeById(int recipeId)
  {
    Recipe foundRecipe = _repo.GetRecipeById(recipeId);
    if(foundRecipe == null){
      throw new Exception("This Recipe Does Not Exist!");
    }
    return foundRecipe;
  }

  internal Recipe EditRecipe(int recipeId, Recipe updatedRecipe, string id)
  {
    Recipe foundRecipe = GetRecipeById(recipeId);
    if (foundRecipe.CreatorId != id)
        {
            throw new Exception("Unauthorized to Edit Recipe");
        }
    foundRecipe.Category = updatedRecipe.Category ?? foundRecipe.Category;
    foundRecipe.Title = updatedRecipe.Title ?? foundRecipe.Title;
    foundRecipe.Instructions = updatedRecipe.Instructions ?? foundRecipe.Instructions;
    foundRecipe.Img = updatedRecipe.Img ?? foundRecipe.Img;

    _repo.EditRecipe(foundRecipe);
    return foundRecipe;

  }

  internal Recipe DeleteRecipe(int recipeId, Account userInfo)
  {

    return _repo.DeleteRecipe(recipeId);
  }
}