using static AllSpice.Models.Recipe;

namespace AllSpice.Services;

public class FavoritesService
{
  private readonly FavoritesRepository _repo;

  public FavoritesService(FavoritesRepository repo)
  {
    _repo = repo;
  }

  internal Favorite addFavorite(Favorite newFavorite)
  {
    return _repo.addFavorite(newFavorite);
  }

  internal Favorite deleteFavorite(int favoriteId, Account userInfo)
  {
    return _repo.deleteFavorite(favoriteId);
  }

  internal List<FavoriteRecipeViewModel> GetAccountFavorites(string accountId)
  {
    return _repo.GetAccountFavorites(accountId);
  }
}