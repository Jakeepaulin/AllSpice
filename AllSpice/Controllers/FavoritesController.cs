namespace AllSpice.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]

public class FavoritesController : ControllerBase
{
  private readonly FavoritesService _fs;
  private readonly Auth0Provider _auth0provider;

  public FavoritesController(FavoritesService fs, Auth0Provider auth0provider)
  {
    _fs = fs;
    _auth0provider = auth0provider;
  }

[HttpPost]
[Authorize]
public async Task<ActionResult<Favorite>> AddFavorite([FromBody] Favorite newFavorite)
  {
    try 
      {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      newFavorite.AccountId = userInfo.Id;
      Favorite addedFavorite = _fs.addFavorite(newFavorite);
      return Ok(addedFavorite);
       }
    catch (Exception e)
  {
  return BadRequest(e.Message);
    }
   }

[HttpDelete("{favoriteId}")]
[Authorize]
public async Task<ActionResult<Favorite>> DeleteFavorite(int favoriteId){
  try 
  {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      Favorite deletedFavorite = _fs.deleteFavorite(favoriteId, userInfo);
      return deletedFavorite;
    }
  catch (Exception e)
  {
    return BadRequest(e.Message);
  }
}

  
}