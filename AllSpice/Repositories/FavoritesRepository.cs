using static AllSpice.Models.Recipe;

namespace AllSpice.Repositories;
public class FavoritesRepository : BaseRepository
{
  public FavoritesRepository(IDbConnection db) : base(db)
  {
  }

  internal Favorite deleteFavorite(int id)
  {
    string sql = @"
    SELECT * FROM  favorites WHERE id = @Id
    ;";
    Favorite favorite = _db.QueryFirstOrDefault<Favorite>(sql, new { id });

    sql = "DELETE FROM favorites WHERE id = @Id LIMIT 1";
    _db.ExecuteScalar(sql, new { id });
    return favorite; 
  }

  internal Favorite addFavorite(Favorite newFavorite)
  {
    string sql = @"
    INSERT INTO favorites (accountId, recipeId)
    VALUES (@AccountId, @RecipeId);
    SELECT LAST_INSERT_ID()
    ;";
    newFavorite.Id = _db.ExecuteScalar<int>(sql, newFavorite);

    return newFavorite;  
    }

  internal List<FavoriteRecipeViewModel> GetAccountFavorites(string accountId)
  {
    string sql = @"
      SELECT 
      r.*,
      COUNT(f.id) AS FavoriteCount,
      f.id AS FavoriteId,
      r.id AS RecipeId,
      a.*
      FROM favorites f
      JOIN recipes r ON r.id = f.recipeId
      JOIN accounts a ON a.id = r.creatorId
      WHERE f.accountId = @accountId
      GROUP BY f.id
     ;";
    return _db.Query<FavoriteRecipeViewModel, Profile, FavoriteRecipeViewModel>(sql, (recipe, profile) =>
    {
      recipe.Creator = profile;
      // recipe.Favorited = true;
      return recipe;
    }, new { accountId }).ToList();
  }
}