namespace AllSpice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
  private readonly Auth0Provider _auth0provider;
  private readonly RecipesService _rs;

  private readonly IngredientsService _is;

  public RecipesController(Auth0Provider auth0provider, RecipesService rs, IngredientsService @is)
  {
    _auth0provider = auth0provider;
    _rs = rs;
    _is = @is;
  }

[HttpPost]
[Authorize]
public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe newRecipe)
  {
  try 
  {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      newRecipe.CreatorId = userInfo.Id;
      Recipe createdRecipe = _rs.CreateRecipe(newRecipe);
      createdRecipe.Creator = userInfo;
      return Ok(createdRecipe);

    }
  catch (Exception e)
  {
  return BadRequest(e.Message);
  }
  }

[HttpGet]
public ActionResult<List<Recipe>> GetAllRecipes()
  {
  try 
    {
      List<Recipe> recipes = _rs.GetAllRecipes();
      return Ok(recipes);
    }
  catch  (Exception e)
  {
  return BadRequest(e.Message);
  }
  }

[HttpGet("{recipeId}")]
[Authorize]
public ActionResult<Recipe> GetRecipeById(int recipeId)
  {
  try 
    {
      Recipe foundRecipe = _rs.GetRecipeById(recipeId);
      return Ok(foundRecipe);
    }
  catch  (Exception e)
  {
  return BadRequest(e.Message);
  }
  }


[HttpGet("{recipeId}/ingredients")]
[Authorize]
public ActionResult<List<Ingredient>> GetIngredientsByRecipe(int recipeId)
{
  try 
  {
      List<Ingredient> ingredients = _is.GetIngredientsByRecipe(recipeId);
      return Ok(ingredients);
    }
  catch (Exception e)
  {
    return BadRequest(e.Message);
  }
}

[HttpPut("{recipeId}")]
[Authorize]
public async Task<ActionResult<Recipe>> EditRecipe(int recipeId, [FromBody] Recipe updatedRecipe)
{
try 
{
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      Recipe newRecipe = _rs.EditRecipe(recipeId, updatedRecipe, userInfo.Id);
      return Ok(newRecipe);
    }
catch (Exception e)
{
  return BadRequest(e.Message);
}
}

[HttpDelete("{recipeId}")]
[Authorize]
public async Task<ActionResult<Recipe>> DeleteRecipe(int recipeId){
  try 
  {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      Recipe deletedRecipe = _rs.DeleteRecipe(recipeId, userInfo);
      return deletedRecipe;
    }
  catch (Exception e)
  {
    return BadRequest(e.Message);
  }
}

}