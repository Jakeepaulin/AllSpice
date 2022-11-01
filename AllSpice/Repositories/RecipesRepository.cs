namespace AllSpice.Repositories;

public class RecipesRepository : BaseRepository
{
  public RecipesRepository(IDbConnection db) : base(db)
  {
  }

  internal Recipe CreateRecipe(Recipe newRecipe)
  {
    string sql = @"
    INSERT INTO recipes (title, instructions, img, category, creatorId)
    VALUES (@Title, @Instructions, @Img, @Category, @CreatorId);
    SELECT LAST_INSERT_ID()
    ;";
    int recipeId = _db.ExecuteScalar<int>(sql, newRecipe);
    newRecipe.Id = recipeId;
    return newRecipe;
  }

  internal Recipe GetRecipeById(int recipeId)
  {
    string sql = @"
    SELECT 
    r.*,
    a.*
    FROM recipes r
    JOIN accounts a ON a.id = r.creatorId
    WHERE r.id = @recipeId
    ;";
    return _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) =>
    {
      recipe.Creator = profile;
      return recipe;
    }, new { recipeId }).FirstOrDefault();
  }

  internal List<Recipe> GetAllRecipes()
  {
    string sql = @"
    SELECT
    r.*,
    a.*
    FROM recipes r
    JOIN accounts a ON a.id = r.creatorId
    ;";
    return _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile)=> 
    {
      recipe.Creator = profile;
      return recipe;
    }).ToList();
  }

 internal Recipe EditRecipe(Recipe updatedRecipe)
  {
    string sql = @"
    UPDATE recipes SET
    title = @Title,
    instructions = @Instructions,
    img = @Img,
    category = @Category
    WHERE id = @Id
    ;";
    _db.ExecuteScalar(sql, updatedRecipe);
    return updatedRecipe;
  }

  internal Recipe DeleteRecipe(int id)
  {
    string sql = @"
    SELECT * FROM  recipes WHERE id = @Id
    ;";
    Recipe recipe = _db.QueryFirstOrDefault<Recipe>(sql, new { id });

    sql = "DELETE FROM recipes WHERE id = @Id";
    _db.ExecuteScalar(sql, new { id });
    return recipe;

  }
}