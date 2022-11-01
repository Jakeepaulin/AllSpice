namespace AllSpice.Repositories;

public class IngredientsRepository : BaseRepository
{
  public IngredientsRepository(IDbConnection db) : base(db)
  {
  }

  internal Ingredient CreateIngredient(Ingredient newIngredient)
  {
    string sql = @"
    INSERT INTO ingredients (name, quantity, recipeId)
    VALUES (@Name, @Quantity, @RecipeId);
    SELECT LAST_INSERT_ID()
    ;";
    int ingredientId = _db.ExecuteScalar<int>(sql, newIngredient);
    newIngredient.Id = ingredientId;
    return newIngredient;  
    }

  internal Ingredient DeleteIngredient(int id)
  {
 string sql = @"
    SELECT * FROM  ingredients WHERE id = @Id
    ;";
    Ingredient ingredient = _db.QueryFirstOrDefault<Ingredient>(sql, new { id });

    sql = "DELETE FROM ingredients WHERE id = @Id";
    _db.ExecuteScalar(sql, new { id });
    return ingredient;  
    }

  internal List<Ingredient> GetIngredientsByRecipe(int recipeId)
  {
    string sql = @"
    SELECT 
    i.*,
    r.*
    FROM ingredients i
    JOIN recipes r ON i.recipeId = r.id
    WHERE i.recipeId = @recipeId
    ;";
    return _db.Query<Ingredient, Recipe, Ingredient>(sql, (ingredient, recipe)=>
    {
      return ingredient;
    }, new{recipeId}).ToList();
  }
}